namespace BattleEngine
{
    internal class GameObject
    {
        public double Direction;
        public double MoveSpeed;

        bool IsMoving;
        Vector Position;
        public GameObject(Vector Pos)
        {
            Position = Pos;
        }
        public virtual void Update(int msElapsed)
        { }
       
    }
}