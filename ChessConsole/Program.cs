using ChessConsole.ChessBoard;
using ChessConsole.ChessBoard.Enums;
using ChessConsole.ChessBoard.Pieces;
using ChessConsole.ChessConsole;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = Board.GetInstance();

                Position pos;
                board.PutPiece(new Rook  (board, pos = new Position(0, 0), Color.White), pos);
                board.PutPiece(new Knight(board, pos = new Position(0, 1), Color.White), pos);
                board.PutPiece(new Bishop(board, pos = new Position(0, 2), Color.White), pos);
                board.PutPiece(new Queen (board, pos = new Position(0, 3), Color.White), pos);
                board.PutPiece(new King  (board, pos = new Position(0, 4), Color.White), pos);
                board.PutPiece(new Bishop(board, pos = new Position(0, 5), Color.White), pos);
                board.PutPiece(new Knight(board, pos = new Position(0, 6), Color.White), pos);
                board.PutPiece(new Rook  (board, pos = new Position(0, 7), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 0), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 1), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 2), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 3), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 4), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 5), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 6), Color.White), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(1, 7), Color.White), pos);

                board.PutPiece(new Rook  (board, pos = new Position(7, 0), Color.Black), pos);
                board.PutPiece(new Knight(board, pos = new Position(7, 1), Color.Black), pos);
                board.PutPiece(new Bishop(board, pos = new Position(7, 2), Color.Black), pos);
                board.PutPiece(new Queen (board, pos = new Position(7, 3), Color.Black), pos);
                board.PutPiece(new King  (board, pos = new Position(7, 4), Color.Black), pos);
                board.PutPiece(new Bishop(board, pos = new Position(7, 5), Color.Black), pos);
                board.PutPiece(new Knight(board, pos = new Position(7, 6), Color.Black), pos);
                board.PutPiece(new Rook  (board, pos = new Position(7, 7), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 0), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 1), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 2), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 3), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 4), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 5), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 6), Color.Black), pos);
                board.PutPiece(new Pawn  (board, pos = new Position(6, 7), Color.Black), pos);

                View.PrintBoard(board);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("---------------------");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}