using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleEngine
{
    public class Map
    {
        private TerrainMap[,] terrain { get; }
        
        internal  HashSet<GameObject> objects { get; } = new HashSet<GameObject>();

        public RectangleF TerrainBounds { get; }

        public IEnumerable<IGameObject> Objects
        {
            get { return objects;}
        }

        public Map()
        {
            terrain = new TerrainMap[320, 240];
            TerrainBounds = new RectangleF(Vector.Zero, new Vector(320, 240));  
        }


        public TerrainMap[,] GetTerrain()
        {
            return (TerrainMap[,])terrain.Clone();
        }

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
            {
                o.Update(msElapsed);
                if(!TerrainBounds.Contains(o.Position))
                {
                    var x = Math.Min(TerrainBounds.Right, Math.Max(TerrainBounds.Left, o.Position.X));
                   var y = Math.Min(TerrainBounds.Top, Math.Max(TerrainBounds.Bottom, o.Position.Y));
                    o.Position = new Vector(x, y);
                }
            }

        }
        
    }

}
