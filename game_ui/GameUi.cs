using game_engine;
using game_ui.ui_elements;

namespace game_ui;

internal class GameUi
{
    public readonly double ActiveZoneToWindowRatio = 0.75;
    private IEnumerable<SelfDrawableElement> drawables;

    public Rectangle PlayableZone
    {
        get
        {
            var activeZone = drawables.First(dr => dr is ActiveZone) as ActiveZone;
            return activeZone!.PlayableZone;
        }
    }

    public GameUi() =>
        drawables = getSelfDrawables();

    public void Draw(GameState gameState)
    {
        foreach (var drawable in drawables)
        {
            if (drawable is ActiveZone a)
                a.Draw(null);
            else if (drawable is Snake s)
                s.Draw(gameState.SnakeCoordinates);
            else if (drawable is Food f)
                f.Draw(new[] { gameState.FoodCoordinate });
        }
    }

    private IEnumerable<SelfDrawableElement> getSelfDrawables()
    {
        var list = new List<SelfDrawableElement>();

        // creates active zone
        int xBorder = 2, yBorder = 1;
        var activeZoneSize = getActiveZoneSize();
        var activeZoneOrigin = new Coordinate((Console.WindowWidth - activeZoneSize.Width) / 2
                                  , (Console.WindowHeight - activeZoneSize.Height) / 2);
        var activeZone = new ActiveZone('@', activeZoneOrigin, activeZoneSize, xBorder, yBorder);

        // creates snake
        var snakeOrigin = new Coordinate(activeZoneOrigin.X + xBorder, activeZoneOrigin.Y + yBorder);
        var snake = new Snake('#', snakeOrigin);

        // creates food
        var food = new Food('$', snakeOrigin);

        list.AddRange(new SelfDrawableElement[] { activeZone, snake, food });
        return list;
    }

    private Rectangle getActiveZoneSize() =>
       new Rectangle
       {
           Width = (int)(Console.WindowWidth * ActiveZoneToWindowRatio),
           Height = (int)(Console.WindowHeight * ActiveZoneToWindowRatio)
       };
}