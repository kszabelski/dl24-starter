using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.FooBarServer
{
    public class GameEngine
    {
        public IDictionary<int, Player> Players { get; private set; }

        public IDictionary<string, int> PlayerTokens { get; private set; }
        public long TurnNumber { get; private set; }

        private Random random = new Random();

        public GameEngine()
        {
            this.Players = new Dictionary<int, Player>();
            this.PlayerTokens = new Dictionary<string, int>();
            this.TurnNumber = 0;
        }

        private string GetLoginHash(string login, string password)
        {
            return string.Format("{0}#{1}", login, password);
        }

        public void AddPlayers(IEnumerable<Tuple<string, string>> logins)
        {
            int nextId = 1;
            if (PlayerTokens.Any())
            {
                nextId = PlayerTokens.Values.Max() + 1;
            }

            foreach (var login in logins)
            {
                var hash = this.GetLoginHash(login.Item1, login.Item2);
                PlayerTokens.Add(hash, nextId);
                Players.Add(nextId, new Player());
                ++nextId;
            }
        }

        public int GetPlayerId(string login, string password)
        {
            var hash = this.GetLoginHash(login, password);
            int id = 0;
            if (this.PlayerTokens.TryGetValue(hash, out id))
            {
                return id;
            }

            return 0;
        }

        public long GetPlayerEnergy(int id)
        {
            return this.Players[id].Energy;
        }

        public void NextTurn()
        {
            // Increase energy for each player
            var newEnergy = random.Next(10);
            foreach (var player in Players.Values)
            {
                player.CallCount = 0;
                player.Energy += newEnergy;
            }

            ++this.TurnNumber;
        }
    }
}
