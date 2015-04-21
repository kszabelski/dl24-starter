using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chupacabra.PlayerCore.Host
{
    public interface IStatusMonitor
    {
        void SetValue(string key, object value);
        void ConfirmTurn();
    }
}
