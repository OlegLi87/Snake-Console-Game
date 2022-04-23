using game_engine;

namespace game_ui.ui_elements;

internal class Food : SelfDrawableElement
{
    public Food(char uiChar, Coordinate relativeCoordinate, ConsoleColor color)
       : base(uiChar, relativeCoordinate, color)
    {
    }

    public override void Draw(GameState gameState)
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(RelativeToCoordinate.X + gameState.FoodCoordinate.X
           , RelativeToCoordinate.Y + gameState.FoodCoordinate.Y);

        Console.Write(UiChar);
    }
}