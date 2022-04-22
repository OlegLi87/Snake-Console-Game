using game_engine;

namespace game_ui.ui_elements;

internal class ActiveZone : SelfDrawableElement
{
    private Rectangle _size;
    private int _borderWidthX;
    private int _borderWidthY;
    private Rectangle? _playableZone;
    public Rectangle PlayableZone
    {
        get
        {
            if (_playableZone is null)
                _playableZone = new Rectangle
                {
                    Width = _size.Width - _borderWidthX * 2,
                    Height = _size.Height - _borderWidthY * 2
                };

            return _playableZone.Value;
        }
    }

    public ActiveZone(char uiChar, Coordinate relativeToCoordinate
       , Rectangle size, int borderWidthX, int borderWidthY) : base(uiChar, relativeToCoordinate)
    {
        _size = size;
        _borderWidthX = borderWidthX;
        _borderWidthY = borderWidthY;
    }

    public override void Draw(IEnumerable<Coordinate>? coordinates, ConsoleColor color = ConsoleColor.White)
    {
        for (int i = 0; i < _size.Height; i++)
        {
            Console.CursorLeft = RelativeToCoordinate.X;
            Console.CursorTop = RelativeToCoordinate.Y + i;

            for (int k = 0; k < _size.Width; k++)
            {
                if (i < _borderWidthY || i + _borderWidthY >= _size.Height)
                    Console.Write(UiChar);
                else if (k < _borderWidthX || k + _borderWidthX >= _size.Width)
                    Console.Write(UiChar);
                else
                    Console.Write(" ");
            }
        }
    }
}