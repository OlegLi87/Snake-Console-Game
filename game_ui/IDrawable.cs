using game_engine;

namespace game_ui;

internal interface IDrawable
{
    void Draw(IEnumerable<Coordinate>? coordinates, ConsoleColor color = ConsoleColor.White);
}