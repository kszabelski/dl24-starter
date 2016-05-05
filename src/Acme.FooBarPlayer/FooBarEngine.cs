using System;
using System.Collections.Generic;
using Chupacabra.PlayerCore.Host;
using Chupacabra.PlayerCore.Service;
using Chupacabra.PlayerCore.Visualizer;
using NLog;

namespace Acme.FooBarPlayer
{
    class FooBarEngine : EngineBase
    {
        public IStatusMonitor Monitor { get; set; }

        public VisualizationHost Viaualization { get; set; }

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

                    var state = StateHelper.Load<Dictionary<int, int>>() ?? new Dictionary<int, int>();
                    int tick = 0;
                    while (true)
                    {
                        //ProcessCommands();
                        ++tick;
                        var turnNo = service.GetTurn();
                        Monitor.SetValue("engine/turn", turnNo);
                        Monitor.SetValue("engine/tick", tick);
                        Logger.Debug("tick {0}, turn {1}", tick, turnNo);
                        state[turnNo] = tick;
                        if (tick%10 == 0)
                        {
                            Logger.Info("data {0}", string.Join(", ", service.GetPrices()));
                        }
                        Monitor.ConfirmTurn();
                        StateHelper.Save(state);

                        Visualize(tick);

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

        private void Visualize(int tick)
        {
            var board = new[]
            {
                new[] {"0", "0", "0"},
                new[] {"0", "0", "0"},
                new[] {"0", "0", "0"}
            };
            tick = tick%3;
            board[tick][tick] = "11";

            Viaualization.Visualize(board);
        }
    }
}
