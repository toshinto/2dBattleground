using System;

namespace BattleEngine
{
    internal class GameObject
    {
        public double Direction;
        public double MoveSpeed;
        public Map Map { get; private set; }
        public bool IsMoving;
        public Vector Position;
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