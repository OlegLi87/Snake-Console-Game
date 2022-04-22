namespace game_engine;

internal abstract class SnakeMember : IMovable
{
    public Coordinate CurrentCoordinate { get; protected set; }
    public Coordinate? PreviousCoordinate { get; protected set; }

    public SnakeMember(Coordinate currentCoordinate) =>
       CurrentCoordinate = currentCoordinate;

    public bool IsOnTheSameCoordinate(Coordinate coordinate) =>
       CurrentCoordinate == coordinate;
    public abstract void Move(Direction? direction);
}
