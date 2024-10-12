using Spectre.Console;

namespace ChessBoard;

public class Menu
{
    private static int _boardSize = 8;
    private static (string Black, string White) _tiles = ("◼", "◻");
    private static string _piece = "\u2656";
    private static string _placement = "A1";
    
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
        while (true)
        {
            Console.Clear();
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Placeholder")
                    .PageSize(10)
                    .AddChoices("Board Size", "Custom Tiles", "Custom Piece","Piece Placement", "Generate Board"));
        
            switch (choice)
            {
                case "Board Size":
                    _boardSize = Board.GetBoardSize();
                    break;
                case "Custom Tiles":
                    _tiles = Board.GetCustomTiles();
                    break;
                case "Custom Piece":
                    _piece = Board.GetCustomPiece();
                    break;
                case "Piece Placement":
                    _placement = Board.GetPiecePlacement();
                    break;
                case "Generate Board":
                    Board.GenerateChessBoard(_boardSize, _tiles, _piece, _placement);
                    return;
            }
        }
    }
}