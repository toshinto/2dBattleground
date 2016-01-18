using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    class Map
    {

        public HashSet<GameObject> objects { get; } = new HashSet<GameObject>();

        internal void RemoveObject(GameObject o)
        {
            objects.Remove(o);
        }
        internal void AddObject(GameObject o)
        {
            objects.Add(o);
        }
        internal void Update(int msElapsed)
        {
            foreach (var o in objects)
                o.Update(msElapsed);
        }
    }
}
