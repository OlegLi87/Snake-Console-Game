using game_engine;
using game_ui;

initConsoleConfig();

var gameUi = new GameUi();
var gameEngine = new GameEngine(gameUi.PlayableZone);

Task.Run(listenToKeys);

while (true)
{
    var gameState = gameEngine.GetGameState();
    if (gameState.IsGameOver)
        break;

    gameUi.Draw(gameState);
    gameEngine.Move();

    Thread.Sleep(1000 / 30);
}

gameUi.GameOver();
Console.ReadKey();


void initConsoleConfig()
{
    Console.SetWindowSize(Console.LargestWindowWidth * 3 / 4, Console.LargestWindowHeight * 3 / 4);
    Console.CursorVisible = false;
}

void listenToKeys()
{
    while (true)
    {
        var key = Console.ReadKey().Key;
        if (key == ConsoleKey.UpArrow)
            gameEngine.ChangeMoveDirection(Direction.Up);
        else if (key == ConsoleKey.DownArrow)
            gameEngine.ChangeMoveDirection(Direction.Down);
        else if (key == ConsoleKey.LeftArrow)
            gameEngine.ChangeMoveDirection(Direction.Left);
        else if (key == ConsoleKey.RightArrow)
            gameEngine.ChangeMoveDirection(Direction.Right);
    }
}

