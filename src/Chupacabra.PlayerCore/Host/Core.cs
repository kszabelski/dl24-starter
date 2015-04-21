using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Chupacabra.PlayerCore.Host
{
    public static class Core
    {
        public static void ConfigureConsoleLogger()
        {
            if (LogManager.Configuration == null)
                LogManager.Configuration = new LoggingConfiguration();

            if (LogManager.Configuration.ConfiguredNamedTargets.Any(t => t.Name == "console"))
                return;

            var targetEngine = new ColoredConsoleTarget()
            {
                Name = "console",
                UseDefaultRowHighlightingRules = true,
                Layout = "${date:format=HH\\:mm\\:ss.fff} ${level:uppercase=true} ${message}",
            };

            LogManager.Configuration.AddTarget("console", targetEngine);
            LogManager.Configuration.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, targetEngine));
            LogManager.ReconfigExistingLoggers();
        }

        public static void RunConsole(IEngine engine, string title, Action<ConsoleKeyInfo> keyHandler = null)
        {
            ConfigureConsoleLogger();
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
