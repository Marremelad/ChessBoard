using System.Net;
using System.Text.RegularExpressions;

namespace ChessBoard;

public abstract class Board
{
    public static int BoardSize;
    public static string? WhiteTile;
    public static string? BlackTile;
    public static string? Piece = "🙂";
    

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
            WhiteTile = "◼";
            BlackTile = "◻";
        }
        else
        {
            Console.WriteLine("What should the white tiles be?");
            string? customTile = Console.ReadLine();
            WhiteTile = string.IsNullOrEmpty(customTile) ? "◼" : customTile;
            
            Console.WriteLine("What should the black tile be?");
            customTile = Console.ReadLine();
            BlackTile = string.IsNullOrEmpty(customTile) ? "◻" : customTile;
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

    public static void GenerateChessBoard()
    {
        
    }
    
    
}   