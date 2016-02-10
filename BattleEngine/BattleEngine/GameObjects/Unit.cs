using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    public class Unit:GameObject
    {
        public override ObjectType Type {  get { return ObjectType.Unit; } }





        public double Life;
        public double MaxLife;
        public Unit(Map m) : base(m)
        {

        }


        public void FireProjectile(double Direction)
        {
            var p = new Projectile(Map, this)
            {
                Position = this.Position,
                Direction = Direction,
                IsMoving = true,
            };
        }

    }
}
