using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Conditions;
using NLog.Config;
using NLog.Targets;

namespace Chupacabra.PlayerCore.Host
{
    public static class Core
    {
        public static void RunConsole(IEngine engine, string title, Action<ConsoleKeyInfo> keyHandler = null)
        {
            Console.Title = title;

            var cts = new CancellationTokenSource();
            var task = engine.Start(cts.Token);
            if (keyHandler != null)
            {
                while (!task.IsCompleted)
                {
                    if (Console.KeyAvailable)
                    {
                        keyHandler(Console.ReadKey(true));
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
            }

            task.Wait(cts.Token);
        }
    }
}
