using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Board board, Position position, Color color) : base(board, position, color)
        {
        }
        public override string Image()
        {
            return "\u265c";
            //return Color == Color.White ? "\u2656" : "\u265c";
            //return Color == Color.White ? "R " : "r ";
        }
    }
}
