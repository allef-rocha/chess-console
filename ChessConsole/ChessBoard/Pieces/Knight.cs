using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Board board, Position position, Color color) : base(board, position, color)
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
