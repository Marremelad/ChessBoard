using Spectre.Console;

namespace ChessBoard;

public class Menu
{
    private static int _boardSize = 8; // Default board size initialized to 8.
    
    private static (string White, string Black) _tiles = ("\u25fc", "\u25fb"); // Default tile colors for the board.
    
    private static string _piece = "\u2656"; // Default piece representation (white rook).
    
    private static string _placement = "A1"; // Default placement for the piece.
    
    // Method to display the main menu and handle user choices.
    public static void MainMenu()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("\nWelcome to the Chess Board Generator!")
                .PageSize(10)
                .AddChoices("Generate board", "Exit"));

        switch (choice)
        {
            case "Generate board":
                GenerationOptionsMenu(); // Navigate to the options menu for board generation.
                break;
            case "Exit":
                Console.WriteLine("\nThank you for using the Chess Board Generator!"); // Exit message.
                break;
        }
    }

    // Method to display generation options and handle user choices.
    private static void GenerationOptionsMenu()
    {
        while (true)
        {
            Console.Clear(); // Clear the console for fresh display.
            Console.WriteLine($"\nCurrent Board Size: {_boardSize}\nWhite Tiles: {_tiles.White}\nBlack Tiles: {_tiles.Black}\nPiece: {_piece}\nPlacement: {_placement}"); // Display current board parameters.
           
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("\nCustomize your board!") // Placeholder title for options menu.
                    .PageSize(10)
                    .AddChoices("Board Size", "Custom Tiles", "Custom Piece", "Piece Placement", "Generate Board", "Exit"));
        
            switch (choice)
            {
                case "Board Size":
                    _boardSize = Board.GetBoardSize(); // Update board size based on user input.
                    break;
                case "Custom Tiles":
                    _tiles = Board.GetCustomTiles(); // Update tile colors based on user input.
                    break;
                case "Custom Piece":
                    _piece = Board.GetCustomPiece(); // Update piece representation based on user input.
                    break;
                case "Piece Placement":
                    _placement = Board.GetPiecePlacement(); // Update piece placement based on user input.
                    break;
                case "Generate Board":
                    Board.GenerateChessBoard(_boardSize, _tiles, _piece, _placement); // Generate the chess board with the specified parameters.
                    return; // Exit the options menu after generating the board.
                case "Exit":
                    Console.WriteLine("\nThank you for using the Chess Board Generator!");
                    return; // Exit program before generation a board.
            }
        }
    }
}
