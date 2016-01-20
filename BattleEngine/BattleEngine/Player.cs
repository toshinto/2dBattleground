using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    public class Player
    {
        const int MaxPlayers = 2;


        public Map Map;

        public string Name;
        internal Unit mainUnit ;



        internal Player(string name,Map m,int PlayerID)
        {
            Map = m;
            Name = name;

            mainUnit = new Unit(m);
            mainUnit.Position = new Vector(100, 100);

        }


        public void UpdateMovement(bool isMoving,double angle)
        {
            mainUnit.IsMoving = isMoving;
            mainUnit.Direction = angle;
        }

        public void FireSpell(int id,Vector pos)
        {

        }
    }
}
