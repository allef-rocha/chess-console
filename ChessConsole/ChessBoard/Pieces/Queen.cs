using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }
        public override string Image()
        {
            return "\u265b";
            //return Color == Color.White ? "\u2655" : "\u265b";
            //return Color == Color.White ? "Q " : "q ";
        }
    }
}
