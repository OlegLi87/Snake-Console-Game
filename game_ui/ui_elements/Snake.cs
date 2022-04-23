using game_engine;

namespace game_ui.ui_elements;

internal class Snake : SelfDrawableElement
{
    public Snake(char uiChar, Coordinate relativeCoordinate, ConsoleColor color)
        : base(uiChar, relativeCoordinate, color)
    {
    }

    public override void Draw(GameState gameState)
    {
        Console.ForegroundColor = Color;
        
        foreach (var cord in gameState.SnakeCoordinates)
        {
            Console.SetCursorPosition(RelativeToCoordinate.X + cord.X, RelativeToCoordinate.Y + cord.Y);
            Console.Write(UiChar);
        }
    }
}