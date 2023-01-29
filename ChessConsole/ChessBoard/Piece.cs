using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard
{
    internal class Piece
    {
        public Board Board { get; set; }
        public Position Position { get; set; }
        public Color Color { get; set; }

        public Piece(Board board, Position position, Color color)
        {
            Board = board;
            Position = position;
            Color = color;
        }
    }
}
