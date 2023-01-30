using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }

        public override string Image()
        {
            return "\u265d";
            //return Color == Color.White ? "\u2657" : "\u265d";
            //return Color == Color.White ? "B " : "b ";
        }
    }
}