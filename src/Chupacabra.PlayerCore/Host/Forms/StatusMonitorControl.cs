using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chupacabra.PlayerCore.Host.Forms
{
    public partial class StatusMonitorControl : UserControl, IStatusMonitor
    {
        private ConcurrentQueue<Tuple<string, string>> _valueQueue = new ConcurrentQueue<Tuple<string, string>>();
        private SynchronizationContext _synchronizationContext;

        public StatusMonitorControl()
        {
            _synchronizationContext = SynchronizationContext.Current;
            InitializeComponent();
        }

        /// <summary>
        /// Schedule updating node in tree.
        /// Possibly called on different thread!
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, object value)
        {
            // Normalize key
            var normalizedKey = "/" +
                         string.Join("/",
                             (key ?? "").Split(@"/\".ToCharArray())
                                 .Where(k => !string.IsNullOrWhiteSpace(k))
                                 .Select(k => k.Trim()));
            var valueText = (value != null) ? value.ToString() : null;
            _valueQueue.Enqueue(Tuple.Create(normalizedKey, valueText));
            _synchronizationContext.Post(_ => UpdateTree(), null);
        }

        private void UpdateTree()
        {
            Tuple<string, string> data;
            while (_valueQueue.TryDequeue(out data))
            {
                SetValueInTree(data.Item1, data.Item2);
            }
        }

        private void SetValueInTree(string rawPath, string value)
        {
            var path = rawPath.Split("/".ToCharArray()).Skip(1);
            var nodes = tvMain.Nodes;
            while (path.Any())
            {
                var key = path.First();
                path = path.Skip(1);
                TreeNode node = null;
                if (nodes.ContainsKey(key))
                {
                    node = nodes[key];
                }
                else
                {
                    // TODO: binary search
                    int i = 0;
                    foreach (TreeNode childNode in nodes)
                    {
                        if (string.Compare(childNode.Name, key, true) > 0) break;
                        ++i;
                    }
                    node = nodes.Insert(i, key, key);
                    node.Expand();
                }
                nodes = node.Nodes;
                if (!path.Any())
                {
                    if (value == null)
                    {
                        node.Remove();
                    }
                    else
                    {
                        node.Text = string.Format("{0}: {1}", key, value);
                    }
                }
            }
        }

        public void ConfirmTurn()
        {
        }
    }
}
