using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Chupacabra.PlayerCore.Host.Forms;

namespace Chupacabra.PlayerCore.Visualizer
{
    public class VisualizationHost : IDisposable
    {
        private readonly string _title;
        private VisualizationDialog _dialog;
        private ApplicationContext _applicationContext;
        private Thread _uiThread;
        private AutoResetEvent _uiInitialized = new AutoResetEvent(false);
        private SynchronizationContext _synchronizationContext;
        private DefaultColorsStack _defaultColorsStack = new DefaultColorsStack();

        public VisualizationHost(string title)
        {
            _title = title;
            _uiThread = new Thread(UIThread);
            _uiThread.SetApartmentState(ApartmentState.STA);
            _uiThread.IsBackground = false;
            _uiThread.Start();
            _uiInitialized.WaitOne();
        }
        public void Visualize(string[][] board)
        {
            if (ItemToRepresentationMap == null)
            {
                ItemToRepresentationMap = new Dictionary<string, IElementRepresentation>();
            }

            if (board == null || board.Length == 0 || board[0].Length == 0)
            {
                // display some error
                return;
            }

            var h = board.Length;
            var w = board[0].Length;
            var scale = _dialog.Scale;

            Bitmap bitmap = new Bitmap(w * scale, h * scale);
            using (var g = Graphics.FromImage(bitmap))
            {
               // g.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                for (int y = 0; y < h; y++)
                {
                    for (int x = 0; x < w; x++)
                    {
                        var currentElement = board[y][x];
                        IElementRepresentation currentElementValue;
                        if (!ItemToRepresentationMap.TryGetValue(currentElement, out currentElementValue))
                        {
                            var brush = _defaultColorsStack.Pop();
                            currentElementValue = new BrushElementRepresentation(brush);
                            ItemToRepresentationMap[currentElement] = currentElementValue;
                        }

                        var elementBitmap = currentElementValue.Bitmap(scale);
                        g.DrawImageUnscaled(elementBitmap, x * scale, y * scale);
                    }
                }

                // draw legend
            }

            _dialog.SetPicture(bitmap);
        }

        public Dictionary<string, IElementRepresentation> ItemToRepresentationMap { get; set; }

        void UIThread()
        {
            _applicationContext = new ApplicationContext();
            _dialog = new VisualizationDialog();
            _dialog.Text = _title;
            _dialog.Hide();
            _synchronizationContext = SynchronizationContext.Current;   // Some control must be created first, so proper synchronization context is installed!
            _uiInitialized.Set();
            Application.Run(_applicationContext);
        }
        
        public void Dispose()
        {
            _applicationContext.ExitThread();
            _uiThread.Join();
        }

        private void ShowWindow()
        {
            _dialog.Show();
            _dialog.BringToFront();
        }

        public void Show()
        {
            _synchronizationContext.Post(_ => ShowWindow(), null);
        }
    }
}
