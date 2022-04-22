using game_engine;

namespace game_ui.ui_elements;

internal abstract class SelfDrawableElement : IDrawable
{
    protected char UiChar;
    protected Coordinate RelativeToCoordinate;

    public SelfDrawableElement(char uiChar, Coordinate relativeCoordinate)
    {
        UiChar = uiChar;
        RelativeToCoordinate = relativeCoordinate;
    }

    public virtual void Draw(IEnumerable<Coordinate>? coordinates, ConsoleColor color = ConsoleColor.White)
    {
        foreach (var cord in coordinates!)
        {
            Console.CursorLeft = RelativeToCoordinate.X + cord.X;
            Console.CursorTop = RelativeToCoordinate.Y + cord.Y;
            Console.Write(UiChar);
        }
    }
}