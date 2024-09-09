using System.ComponentModel;
using System.ComponentModel.Design;
using System.Numerics;

namespace ChessBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable Declarations:
            
            int boardSize = 0; //Holds the size of the chessboard.
            bool isNumber; //Used to validate whether the input is valid.

            string? whiteTiles = "◼︎"; //Default symbols for white and black tiles on the chessboard.
            string ? blackTiles = "◻︎";
            string piece = "🙂"; //Represents the piece to be placed on the board, defaulting to "🙂".

            //Get Chessboard Size from User:
            
            do { //This loop asks the user to input the size of the chessboard (for example 8 for 8x8).
                Console.WriteLine("Please enter size of chessboard"); 
                string? numberOfSquares = Console.ReadLine();
                isNumber = int.TryParse(numberOfSquares, out boardSize);
            } while (!isNumber || boardSize <= 0); //It keeps asking until a valid number is entered.

            //Ask for Custom Tiles:

            Console.WriteLine("Do you want custom tiles? y/n"); //The user is prompted to choose if they they want custom symbols for the tiles.
            string? answer = Console.ReadLine(); ////Holds the user's response for custom tiles.


            if (answer?.ToLower() == "y") { //If "y" is entered, the user can input their desired symbols for the white and black tiles.
                    Console.WriteLine("What should the white tiles be?");
                    whiteTiles = Console.ReadLine();

                    Console.WriteLine("What should the black tiles be?");
                    blackTiles  = Console.ReadLine();
            }
            

            //Get Piece Placement:

            Console.WriteLine("Where do you want to place your piece?"); //The user is asked where they want to place their piece on the board (for example "a1", "b2", etc).
            string? placement = Console.ReadLine();

            //Chessboard Generation:

            for (int i = boardSize ; i > 0; i--) { //Outer Loop (i): Iterates over the rows of the chessboard.
                int row = i; //Represents the row number.

                for (int j = 0; j < boardSize; j++) { //Inner Loop (j): Iterates over the columns of each row.
                    int column = j + 97; //Converts the column number into a ASCII character number.
                    string position = $"{(char)(column)}{row}"; //Current row and column are added together to create a position like a1, b2 etc. 

                    if (placement?.ToLower() == position) { //If the user's specified piece placement matches the current position, it prints the piece (🙂).
                        Console.Write(piece);
                    }
                    else {
                        Console.Write((i + j) % 2 == 0 ? whiteTiles : blackTiles); //Otherwise, it prints the white or black tile based on the current square’s position (alternating between them using (i + j) % 2).
                    }    
                }
                Console.WriteLine(); //Prints a new line after each row.
            }
        }
    }
}
