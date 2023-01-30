using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class King : Piece
    {
        public King(Board board,  Color color) : base(board, color)
        {
        }

        public override string Image()
        {
            return "\u265a";
            //return Color == Color.White ? "\u2654" : "\u265a";
            //return Color == Color.White ? "K " : "k ";
        }
    }
}
