using System.Net;
using System.Text.RegularExpressions;

namespace ChessBoard;

public abstract class Board
{
    private static string? _whiteTile;
    private static string? _blackTile;
    
    public static int GetBoardSize()
    {
        Console.WriteLine("Please enter board size.");
        int boardSize;
        while (!int.TryParse(Console.ReadLine(), out boardSize) || boardSize is < 1 or > 8)
        {
            Console.WriteLine("Invalid input. Board size must be an integer between 1 and 8.");
        }

        return boardSize;
    }

    public static void GetCustomTiles()
    {
        Console.WriteLine("Do you want custom tiles for your board? (y/n)");
        string? userInput = Console.ReadLine()?.ToLower();

        if (userInput != "y")
        {
            _whiteTile = "◼";
            _blackTile = "◻";
        }
        else
        {
            Console.WriteLine("What should the white tiles be?");
            string? customTile = Console.ReadLine();
            _whiteTile = string.IsNullOrEmpty(customTile) ? "◼" : customTile;
            
            Console.WriteLine("What should the black tile be?");
            customTile = Console.ReadLine();
            _blackTile = string.IsNullOrEmpty(customTile) ? "◻" : customTile;
        }
    }

    public static string GetCustomPiece()
    {
        Console.WriteLine("Do you want a custom piece?");
        
        string? userInput = Console.ReadLine()?.ToLower();
        if (userInput != "y") return "🙂";

        string? piece = Console.ReadLine();
        return string.IsNullOrEmpty(piece) ? "🙂" : piece;
    }

    public static string GetPiecePlacement()
    {
        Regex regex = new Regex(@"^[A-H][1-8]$");

        Console.WriteLine("Where do you wan to place your piece?");

        string? placement;
        while (string.IsNullOrEmpty(placement = Console.ReadLine()) || !regex.IsMatch(placement))
        {
            Console.WriteLine("Invalid input. Please enter a valid position (e.g., A1, H8).");
        }
        
        return placement;
    }

    public static void GenerateChessBoard(int boardSize, string placement, string piece)
    {
        for (int i = boardSize; i > 0; i--)
        { //Outer Loop (i): Iterates over the rows of the chessboard. Also makes sure that the chessboard is flipped correctly (a1 at the bottom left).
            int row = i; //Represents the row number.

            for (int j = 0; j < boardSize; j++)
            { //Inner Loop (j): Iterates over the columns of each row.
                int column = j + 97; //Converts the column number into an ASCII character number.
                string
                    position =
                        $"{(char)(column)}{row}"; //Current row and column are added together to create a position like a1, b2 etc. 

                if (placement?.ToLower() == position)
                { //If the user's specified piece placement matches the current position, it prints the piece (🙂).
                    Console.Write(piece);
                }
                else
                {
                    Console.Write((i + j) % 2 == 0
                        ? _whiteTile
                        : _blackTile); //Otherwise, it prints the white or black tile based on the current square’s position (alternating between them using (i + j) % 2).
                }
            }

            Console.WriteLine(); //Prints a new line after each row.
        }
    }
    
    
}    