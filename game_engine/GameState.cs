namespace game_engine;

public struct GameState
{
    public bool IsGameOver { get; init; }
    public IEnumerable<Coordinate> SnakeCoordinates { get; init; }
    public Coordinate FoodCoordinate { get; set; }
    public bool IsFoodEaten { get; set; }
}