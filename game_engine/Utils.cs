namespace game_engine;

internal static class Utils
{
    public static int GetRandomNumber(int from, int to)
    {
        var rand = new Random();
        return rand.Next(from, to);
    }
}