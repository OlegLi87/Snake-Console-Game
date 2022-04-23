using game_engine;

namespace game_ui.ui_elements;

internal class ScoreDisplay : SelfDrawableElement
{
    public ScoreDisplay(char uiChar, Coordinate relativeCoordinate, ConsoleColor color)
             : base(uiChar, relativeCoordinate, color)
    {
    }

    public override void Draw(GameState gameState)
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(RelativeToCoordinate.X, RelativeToCoordinate.Y);
        Console.Write($"Your score is : {gameState.Score}");
    }
}