namespace game_engine;

internal class SnakeBodyPiece : SnakeMember
{
    private SnakeMember _parentBodyPiece;
    public SnakeBodyPiece(SnakeMember parentBodyPiece, Coordinate currentCoordinate) : base(currentCoordinate) =>
        _parentBodyPiece = parentBodyPiece;

    public override void Move(Direction? direction)
    {
        PreviousCoordinate = CurrentCoordinate;
        CurrentCoordinate = _parentBodyPiece.PreviousCoordinate!;
    }
}