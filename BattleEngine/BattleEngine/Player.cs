using System;
using System.Collections.Concurrent;
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
        internal Unit mainUnit;

        readonly ConcurrentQueue<Tuple<int, Vector>> pendingSpellCasts
            = new ConcurrentQueue<Tuple<int, Vector>>();

        internal Player(string name,Map m,int PlayerID)
        {
            Map = m;
            Name = name;

            mainUnit = new Unit(m);
            mainUnit.Position = new Vector(100, 100);

        }

        internal void Update(int msElapsed)
        {
            processSpellCasts();
        }

        void processSpellCasts()
        {
            Tuple<int, Vector> spellCast;
            while (pendingSpellCasts.TryDequeue(out spellCast))
            {

                //if id is 0, cast spell
                if (spellCast.Item1 == 0)
                {
                    var d = mainUnit.Position.AngleTo(spellCast.Item2);
                    mainUnit.FireProjectile(d);
                }
            }
        }

        public void SetMovement(bool isMoving, double angle)
        {
            mainUnit.IsMoving = isMoving;
            mainUnit.Direction = angle;
        }

        public void FireSpell(int id, Vector pos)
        {
            pendingSpellCasts.Enqueue(new Tuple<int, Vector>(id, pos));
        }
    }
}
