using System.Text.RegularExpressions;

namespace ChessBoard;

public abstract class Board
{
    // Method to get the size of the chess board from user input.
    public static int GetBoardSize()
    {
        Console.WriteLine("\n Please enter a desired board size between 1 and 8.");
        int.TryParse(Console.ReadLine(), out int boardSize);
        return boardSize is > 0 and < 9 ? boardSize : 8;
    }

    // Method to get custom tiles for the chess board from user input.
    public static (string, string) GetCustomTiles()
    {
        string? customTile; // Variable to hold the custom tile input.

        Console.WriteLine("\nWhat should the white tiles be?");
        string whiteTile = string.IsNullOrEmpty(customTile = Console.ReadLine()) ? "◼" : customTile; // Get white tile or default.

        Console.WriteLine("What should the black tile be?");
        string blackTile = string.IsNullOrEmpty(customTile = Console.ReadLine()) ? "◻" : customTile; // Get black tile or default.

        return (whiteTile, blackTile); // Return the custom tiles.
    }

    // Method to get a custom chess piece from user input.
    public static string GetCustomPiece()
    {
        Console.WriteLine("\nWhat should the custom piece be?");
        string? piece; // Variable to store the custom piece input.
        return string.IsNullOrEmpty(piece = Console.ReadLine()) ? "\u2656" : piece; // Return custom piece or default.
    }

    // Method to get the placement of a piece on the chess board from user input.
    public static string GetPiecePlacement()
    {
        Regex regex = new Regex(@"^[A-Ha-h][1-8]$"); // Regex to validate chess board positions.

        Console.WriteLine("\nWhere do you wan to place your piece? (e.g., A1, H8).");
        string? placement; // Variable to store the placement input.
        while (string.IsNullOrEmpty(placement = Console.ReadLine()) || !regex.IsMatch(placement))
        {
            Console.WriteLine("\nInvalid input. Please enter a valid position (e.g., A1, H8).");
        }

        return placement; // Return the valid piece placement.
    }

    // Method to generate and display the chess board.
    public static void GenerateChessBoard(int boardSize, (string, string) tiles, string piece, string placement)
    {
        Console.Clear();
        for (int i = boardSize; i > 0; i--)
        {
            int row = i; // Variable for the current row.

            for (int j = 0; j < boardSize; j++)
            {
                int column = j + 97; // Calculate ASCII value for column letters (a-h).
                string position = $"{(char)(column)}{row}"; // Create the position string (e.g., A1).

                if (placement?.ToLower() == position)
                {
                    Console.Write(piece); // Place the custom piece if the position matches.
                }
                else
                {
                    // Print the appropriate tile based on the current position.
                    Console.Write((i + j) % 2 == 0 ? tiles.Item1 : tiles.Item2);
                }
                Console.Write(" "); // Print a space for formatting.
            }
            Console.WriteLine(); // Move to the next line after finishing a row.
        }
    }
}
