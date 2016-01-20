using System;

namespace BattleEngine
{
    internal abstract class GameObject : IGameObject
    {
        public Map Map { get; }

        public double Direction { get; set; }
        public double MoveSpeed { get; set; }
        public bool IsMoving { get; set; }
        public Vector Position { get; set; }

        public abstract ObjectType Type { get; }


        public virtual void Update(int msElapsed)
        {
            if(IsMoving)
            {
                var d = (MoveSpeed * msElapsed) / 1000;
                var p = Position.PolarProjection(Direction, d);
                Position = p;
            }
            
        }
        public GameObject(Map m)
        {
            Map = m;
            Map.AddObject(this);
        }
    }
}