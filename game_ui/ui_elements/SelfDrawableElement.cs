using game_engine;

namespace game_ui.ui_elements;

internal abstract class SelfDrawableElement : IDrawable
{
    protected char UiChar;
    protected Coordinate RelativeToCoordinate;
    protected ConsoleColor Color;
    public SelfDrawableElement(char uiChar, Coordinate relativeCoordinate, ConsoleColor color)
    {
        UiChar = uiChar;
        RelativeToCoordinate = relativeCoordinate;
        Color = color;
    }

    public abstract void Draw(GameState gameState);
}