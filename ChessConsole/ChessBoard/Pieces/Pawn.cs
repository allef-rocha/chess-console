using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, Position position, Color color) : base(board, position, color)
        {
        }
        public override string Image()
        {
            return "\u265f";
            //return Color == Color.White ? "\u2659" : "\u265f";
            //return Color == Color.White ? "P " : "p ";
        }
    }
}
