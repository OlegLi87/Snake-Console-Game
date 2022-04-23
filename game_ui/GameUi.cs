using game_engine;
using game_ui.ui_elements;

namespace game_ui;

internal class GameUi
{
    public readonly double ActiveZoneToWindowRatio = 0.75;
    private IEnumerable<SelfDrawableElement> _drawables;

    public Rectangle PlayableZone
    {
        get
        {
            var activeZone = _drawables.First(dr => dr is ActiveZone) as ActiveZone;
            return activeZone!.PlayableZone;
        }
    }

    public GameUi() =>
        _drawables = getSelf_Drawables();

    public void Draw(GameState gameState)
    {
        foreach (var drawable in _drawables)
            drawable.Draw(gameState);
    }

    public void GameOver()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(Console.WindowWidth / 2 - "Game Over".Length / 2
           , Console.WindowHeight / 2);

        Console.Write("Game Over");
    }

    private IEnumerable<SelfDrawableElement> getSelf_Drawables()
    {
        var list = new List<SelfDrawableElement>();

        // creates active zone
        int xBorder = 2, yBorder = 1;
        var activeZoneSize = getActiveZoneSize();
        var activeZoneOrigin = new Coordinate((Console.WindowWidth - activeZoneSize.Width) / 2
                                  , (Console.WindowHeight - activeZoneSize.Height) / 2);
        var activeZone = new ActiveZone('@', activeZoneOrigin, activeZoneSize, xBorder, yBorder, ConsoleColor.Blue);

        // creates snake
        var snakeOrigin = new Coordinate(activeZoneOrigin.X + xBorder, activeZoneOrigin.Y + yBorder);
        var snake = new Snake('#', snakeOrigin, ConsoleColor.Green);

        // creates food
        var food = new Food('$', snakeOrigin, ConsoleColor.Red);

        // creates score display
        var scoreDisplay = new ScoreDisplay(default, new Coordinate(0, 0), ConsoleColor.Cyan);

        list.AddRange(new SelfDrawableElement[] { activeZone, snake, food, scoreDisplay });
        return list;
    }

    private Rectangle getActiveZoneSize() =>
       new Rectangle
       {
           Width = (int)(Console.WindowWidth * ActiveZoneToWindowRatio),
           Height = (int)(Console.WindowHeight * ActiveZoneToWindowRatio)
       };
}