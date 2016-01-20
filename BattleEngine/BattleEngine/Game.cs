using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    public class Game
    {
        Map map;
        List<Player> Players = new List<Player>();
        public Player HostingPlayer { get; }


        public Game(string hostname)
        {
            map = new Map();
            HostingPlayer = new Player(hostname, map,0);
            Players.Add(HostingPlayer);
        }
        public void Update(int msElapsed)
        {
            map.Update(msElapsed);

        }
    }
    
}
