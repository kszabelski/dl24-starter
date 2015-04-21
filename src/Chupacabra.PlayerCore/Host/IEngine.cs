using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chupacabra.PlayerCore.Host
{
    /// <summary>
    /// Interface implemented by player engines.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Starts engine.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Start(CancellationToken cancellationToken);
    }
}
