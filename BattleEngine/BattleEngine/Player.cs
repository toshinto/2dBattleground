using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    public class Player
    {
        internal Map Map;
        public string Name;
        internal Unit mainUnit ;


        internal Player(string name,Map m)
        {
            Name = name;
            mainUnit = new Unit(m);
            Map = m;

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
