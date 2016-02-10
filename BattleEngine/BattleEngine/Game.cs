using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    public class Game
    {
        Map map = new Map();
        List<Player> Players = new List<Player>();

        public Player HostingPlayer { get; }

        /// <summary>
        /// Pravi nov game s prazen film. 
        /// </summary>
        public Game()
        {

        }

        /// <summary>
        /// Pravi nov Game s nqkav hosting player. 
        /// </summary>
        public Game(string hostname)
        {
            HostingPlayer = new Player(hostname, map,0);
            Players.Add(HostingPlayer);
        }

        public void Update(int msElapsed)
        {
            map.Update(msElapsed);

            foreach (var p in Players)
                p.Update(msElapsed);
        }
    }
    
}
