using System.Text.RegularExpressions;

namespace ChessBoard;

public abstract class Board
{
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

    public static (string, string) GetCustomTiles()
    {
        Console.WriteLine("Do you want custom tiles for your board? (y/n)");
        string? userInput = Console.ReadLine()?.ToLower();

        if (userInput != "y")
        {
            return ("◼", "◻");
           
        }

        string? customTile;
        
        Console.WriteLine("What should the white tiles be?");
        string whiteTile = string.IsNullOrEmpty(customTile = Console.ReadLine()) ? "◼" : customTile;
            
        Console.WriteLine("What should the black tile be?");
        string blackTile = string.IsNullOrEmpty(customTile = Console.ReadLine()) ? "◻" : customTile;

        return (whiteTile, blackTile);
    }

    public static string GetCustomPiece()
    {
        Console.WriteLine("What should the custom piece be?");
        string? piece;
        return string.IsNullOrEmpty(piece = Console.ReadLine()) ? "\u2656" : piece;
    }

    public static string GetPiecePlacement()
    {
        Regex regex = new Regex(@"^[A-Ha-h][1-8]$");
        
        Console.WriteLine("Where do you wan to place your piece? (e.g., A1, H8).");
        string? placement;
        while (string.IsNullOrEmpty(placement = Console.ReadLine()) || !regex.IsMatch(placement))
        {
            Console.WriteLine("Invalid input. Please enter a valid position (e.g., A1, H8).");
        }
        
        return placement;
    }

    public static void GenerateChessBoard(int boardSize, (string, string) tiles, string piece, string placement)
    {
        for (int i = boardSize; i > 0; i--)
        { 
            int row = i; 

            for (int j = 0; j < boardSize; j++)
            { 
                int column = j + 97;
                string position = $"{(char)(column)}{row}"; 

                if (placement?.ToLower() == position)
                { 
                    Console.Write(piece);
                }
                else
                {
                    Console.Write((i + j) % 2 == 0 ? tiles.Item1 : tiles.Item2);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}    