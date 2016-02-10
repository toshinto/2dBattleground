using System;
using System.IO;

namespace BattleEngine
{
    public class GameObject : IGameObject
    {
        /// <summary>
        /// gets the distance moved since last frame
        /// </summary>
        protected double DistanceMoved { get; private  set;}
        

        public Map Map { get; }

        public double Direction { get; set; }
        public double MoveSpeed { get; set; } = 50;
        public bool IsMoving { get; set; }
        public Vector Position { get; set; }

        public virtual ObjectType Type { get; }

        public virtual void Serialize(BinaryWriter w)
        {
            w.Write(Position.X);
            w.Write(Position.Y);
            w.Write(Direction);
            w.Write(MoveSpeed);
            w.Write(IsMoving);
        }

        public virtual void DeSerialize(BinaryReader r)
        {
            var x = r.ReadDouble();
            var y = r.ReadDouble();
            var d = r.ReadDouble();
            var m = r.ReadDouble();
            IsMoving = r.ReadBoolean();
            Position = new Vector(x,y);
            Direction = d;
            MoveSpeed = m;
        }


        public virtual void Update(int msElapsed)
        {
            if (IsMoving)
            {
                DistanceMoved = (MoveSpeed * msElapsed) / 1000;
                var newPosition = Position.PolarProjection(Direction, DistanceMoved);
                Position = newPosition;
            }
            else
                DistanceMoved = 0;
            
        }
        public GameObject(Map m)
        {
            Map = m;
            Map.AddObject(this);
        }
    }
}