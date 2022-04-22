using game_engine;
using game_ui;

Console.SetWindowSize(Console.LargestWindowWidth * 3 / 4, Console.LargestWindowHeight * 3 / 4);
Console.CursorVisible = false;

var gameUi = new GameUi();
var gameEngine = new GameEngine(gameUi.PlayableZone);

while (true)
{
    var gameState = gameEngine.GetGameState();
    if (gameState.IsGameOver)
        break;

    gameUi.Draw(gameState);
    gameEngine.Move();

    Thread.Sleep(16);
}


Console.ReadKey();


