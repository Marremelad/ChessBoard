using Spectre.Console;

namespace ChessBoard;

public class Menu
{
    public static void MainMenu()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Welcome to the Chess Board Generator!")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices("Generate board", "Exit"));

        switch (choice)
        {
            case "Generate board":
                Board.GenerateChessBoard(Board.GetBoardSize(), Board.GetCustomTiles(), Board.GetCustomPiece(), Board.GetPiecePlacement());
                break;
            case "Exit":
                Console.WriteLine("Thank you for using the Chess Board Generator!");
                break;
        }
    }
}