using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board,  color)
        {
        }

        public override string Image()
        {
            return "\u265e";
            //return Color == Color.White ? "\u2658" : "\u265e";
            //return Color == Color.White ? "N " : "n ";
        }
    }
}
