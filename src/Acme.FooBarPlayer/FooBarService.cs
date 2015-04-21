using System.Collections.Generic;
using System.Text.RegularExpressions;
using Chupacabra.PlayerCore.Service;

namespace Acme.FooBarPlayer
{
    class FooBarService : ServiceBase
    {
        public FooBarService(string hostname, int port)
            : base(hostname, port)
        {

        }

        public void CommandWithNoParameters()
        {
            this.Client.WriteLine("COMMAND0");
            ProcessResponseHeader();
        }

        public int GetTurn()
        {
            this.Client.WriteLine("TURN");
            ProcessResponseHeader();
            return int.Parse(this.Client.ReadLine());
        }
    }
}
