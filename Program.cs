//Lab 2 - Schackbräde
//Mauricio Corte
//.NET24

namespace ChessBoard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board.GenerateChessBoard(Board.GetBoardSize(), Board.GetCustomTiles(), Board.GetCustomPiece(), Board.GetPiecePlacement());
        }
    }
}
