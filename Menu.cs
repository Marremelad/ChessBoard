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
                .AddChoices("Generate board", "Exit"));

        switch (choice)
        {
            case "Generate board":
                GenerationOptionsMenu();
                break;
            case "Exit":
                Console.WriteLine("Thank you for using the Chess Board Generator!");
                break;
        }
    }

    private static void GenerationOptionsMenu()
    {
        int boardSize = 8;
        var tiles = ("◼", "◻");
        string piece = "\u2656";
        string placement = "A1";
        
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Placeholder")
                .PageSize(10)
                .AddChoices("Board Size", "Custom Tiles", "Custom Piece", "Generate Standard Board"));

        switch (choice)
        {
            case "Board Size":
                boardSize = Board.GetBoardSize();
                break;
            case "Custom Tiles":
                tiles = Board.GetCustomTiles();
                break;
            case "Custom Piece":
                piece = Board.GetCustomPiece();
                break;
            case "Generate Standard Board":
                break;
        }
        Board.GenerateChessBoard(boardSize, tiles, piece, placement);

    }
}