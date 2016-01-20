using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    class Projectile : GameObject
    {
        public override ObjectType Type {  get { return ObjectType.Projectile; } }


        public Unit Owner { get; }
        public Projectile(Map m,Unit o) : base(m)
        {

            Owner = o;
        }
        public override void Update(int msElapsed)
        {
            base.Update(msElapsed);
            // Check for targets
            var u = Map.objects
                .OfType<Unit>()
                .Where(o => o.Position.DistanceTo(this.Position) < 1)
                .FirstOrDefault();
            if (u != null)
            {
                //deal damage
                u.Life -= 5;

                //check if unit dead
                if (u.Life < 0)
                    Map.RemoveObject(u);

                //remove the projectile
                Map.RemoveObject(this);
            }
        }
    }
}
