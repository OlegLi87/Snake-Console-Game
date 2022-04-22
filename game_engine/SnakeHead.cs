namespace game_engine;

internal class SnakeHead : SnakeMember
{
    public SnakeHead(Coordinate currentCoordinate) : base(currentCoordinate) { }

    public override void Move(Direction? direction)
    {
        PreviousCoordinate = CurrentCoordinate;

        (int x, int y) = direction switch
        {
            Direction.Down => (CurrentCoordinate.X, CurrentCoordinate.Y + 1),
            Direction.Up => (CurrentCoordinate.X, CurrentCoordinate.Y - 1),
            Direction.Left => (CurrentCoordinate.X - 1, CurrentCoordinate.Y),
            Direction.Right => (CurrentCoordinate.X + 1, CurrentCoordinate.Y),
            _ => default
        };

        CurrentCoordinate = new Coordinate(x, y);
    }
}
