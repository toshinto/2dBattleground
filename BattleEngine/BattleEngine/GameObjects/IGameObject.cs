namespace BattleEngine
{
    public interface IGameObject
    {
        double Direction { get; }
        double MoveSpeed { get;  }
        bool IsMoving { get; }
        Vector Position { get; }

        ObjectType Type { get; }
    }
}