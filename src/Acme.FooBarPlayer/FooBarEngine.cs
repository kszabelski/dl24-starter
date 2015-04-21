using System;
using System.Collections.Generic;
using Chupacabra.PlayerCore.Host;
using Chupacabra.PlayerCore.Service;
using NLog;

namespace Acme.FooBarPlayer
{
    class FooBarEngine : EngineBase
    {
        public IStatusMonitor Monitor { get; set; }

        void IgnoreErrors(Action action, IList<int> errorCodes)
        {
            try 
            {
                action();
            }
            catch (ServerException se)
            {
                if (errorCodes.Contains(se.ErrorCode))
                {
                    Logger.Warn("INGORING: {0}", se.Message);
                }
                else
                    throw;
            }

        }

        protected override void Run()
        {
            try
            {
                Logger.Info("Processing started.");
                using (var service = new FooBarService(ServerHostname, ServerPort))
                {
                    service.Login(Login, Password);
                    int tick = 0;
                    while (true)
                    {
                        //ProcessCommands();
                        ++tick;
                        var turnNo = service.GetTurn();
                        Monitor.SetValue("engine/turn", turnNo);
                        Monitor.SetValue("engine/tick", tick);
                        Logger.Info("tick {0}, turn {1}", tick, turnNo);
                        if (tick%10 == 0)
                        {
                            Logger.Info("data {0}", string.Join(", ", service.GetPrices()));
                        }
                        Monitor.ConfirmTurn();
                        if (_cancellationToken.WaitHandle.WaitOne(2000))
                        {
                            break;
                        }
                    }
                }
                Logger.Info("Processing finished.");

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
        }
    }
}
