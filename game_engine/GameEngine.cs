namespace game_engine;

public class GameEngine
{
    private const int MIN_SNAKE_LENGTH = 5;
    private const int POINTS_FOR_EAT = 10;
    private Direction _snakeMoveDirection;
    private Rectangle _activeZone;
    private Snake _snake;
    private Coordinate _foodCoordinate;
    private int _score;

    public GameEngine(Rectangle activeZone)
    {
        _activeZone = activeZone;
        _snakeMoveDirection = (Direction)Utils.GetRandomNumber(0, Enum.GetNames(typeof(Direction)).Count());
        _snake = new Snake(getStartCoordinate(), MIN_SNAKE_LENGTH);
        _foodCoordinate = getFoodCoordinate();
    }

    public void Move() =>
      _snake.Move(_snakeMoveDirection);

    public void ChangeMoveDirection(Direction direction)
    {
        if ((_snakeMoveDirection == Direction.Up && direction == Direction.Down)
           || (_snakeMoveDirection == Direction.Down && direction == Direction.Up)
            || (_snakeMoveDirection == Direction.Left && direction == Direction.Right)
             || (_snakeMoveDirection == Direction.Right && direction == Direction.Left))
            return;

        _snakeMoveDirection = direction;
    }

    public GameState GetGameState()
    {
        checkIfFoodEaten();

        return new GameState
        {
            IsGameOver = isGameOver(),
            SnakeCoordinates = _snake.GetAllCoordinates(),
            FoodCoordinate = _foodCoordinate,
            Score = _score
        };
    }

    private Coordinate getStartCoordinate()
    {
        (int x, int y) = _snakeMoveDirection switch
        {
            Direction.Up => (Utils.GetRandomNumber(0, _activeZone.Width), _activeZone.Height - 1),
            Direction.Down => (Utils.GetRandomNumber(0, _activeZone.Width), 0),
            Direction.Right => (0, Utils.GetRandomNumber(0, _activeZone.Height)),
            Direction.Left => (_activeZone.Width - 1, Utils.GetRandomNumber(0, _activeZone.Height)),
            _ => default
        };

        return new Coordinate(x, y);
    }

    private Coordinate getFoodCoordinate()
    {
        Coordinate coord;

        do
        {
            coord = new Coordinate(Utils.GetRandomNumber(0, _activeZone.Width - 1)
                                      , Utils.GetRandomNumber(0, _activeZone.Height - 1));
        }
        while (_snake.IsCoordinateOnSnake(coord));

        return coord;
    }

    private bool isGameOver()
    {
        var headCoord = _snake.GetHeadCoordinate();

        // checking if snake moved beyond active zone.
        if (headCoord.X >= _activeZone.Width || headCoord.X < 0 || headCoord.Y < 0 || headCoord.Y >= _activeZone.Height)
            return true;

        if (_snake.IsCoordinateOnSnake(headCoord, false))
            return true;

        return false;
    }

    private void checkIfFoodEaten()
    {
        if (_snake.IsCoordinateOnSnake(_foodCoordinate))
        {
            _score += POINTS_FOR_EAT;
            _snake.SnakeGrow();
            _foodCoordinate = getFoodCoordinate();
        }
    }

}
