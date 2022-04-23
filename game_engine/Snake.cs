namespace game_engine;

internal class Snake : IMovable
{
    private readonly int _minLength;
    private List<SnakeMember> _snakeMembers = new();

    public Snake(Coordinate coordinate, int minLength)
    {
        _snakeMembers.Add(new SnakeHead(coordinate));
        _minLength = minLength;
    }

    public void Move(Direction? direction)
    {
        var head = _snakeMembers.First(sm => sm is SnakeHead);
        head.Move(direction);

        var bodyPieces = _snakeMembers.Where(sm => sm is SnakeBodyPiece);
        foreach (var bp in bodyPieces)
            bp.Move(null);

        // Enlarging the snake at game start up to minimum length.
        if (_snakeMembers.Count < _minLength)
            SnakeGrow();
    }

    public bool IsCoordinateOnSnake(Coordinate coordinate, bool checkHead = true)
    {
        var membersToCheck = checkHead ? _snakeMembers : _snakeMembers.Where(sm => sm is not SnakeHead);
        var hittedMember = _snakeMembers
                             .FirstOrDefault(sm => sm.IsOnTheSameCoordinate(coordinate) && (sm is not SnakeHead || checkHead));

        return hittedMember is not null;
    }

    public void SnakeGrow()
    {
        var lastSnakeMember = _snakeMembers[^1];
        var snakeBodyPiece = new SnakeBodyPiece(lastSnakeMember, lastSnakeMember.PreviousCoordinate!);
        _snakeMembers.Add(snakeBodyPiece);
    }

    public Coordinate GetHeadCoordinate() =>
       _snakeMembers.First(sm => sm is SnakeHead).CurrentCoordinate;

    public IEnumerable<Coordinate> GetAllCoordinates() =>
       _snakeMembers.Select(sm => sm.CurrentCoordinate);

}