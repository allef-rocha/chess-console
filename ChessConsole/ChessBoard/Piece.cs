using ChessConsole.ChessBoard.Enums;
using ChessConsole.ChessBoard.Pieces;

namespace ChessConsole.ChessBoard
{
    abstract class Piece
    {
        public Board Board { get; set; }
        public Color Color { get; set; }

        public Piece(Board board, Color color)
        {
            Board = board;
            Color = color;
        }

        public static Piece Parse(char pieceChar, Board brd)
        {
            switch (pieceChar)
            {
                case 'p':
                    return new Pawn(brd, Color.Black);
                case 'n':
                    return new Knight(brd, Color.Black);
                case 'b':
                    return new Bishop(brd, Color.Black);
                case 'r':
                    return new Rook(brd, Color.Black);
                case 'q':
                    return new Queen(brd, Color.Black);
                case 'k':
                    return new King(brd, Color.Black);
                case 'P':
                    return new Pawn(brd, Color.White);
                case 'N':
                    return new Knight(brd, Color.White);
                case 'B':
                    return new Bishop(brd, Color.White);
                case 'R':
                    return new Rook(brd, Color.White);
                case 'Q':
                    return new Queen(brd, Color.White);
                case 'K':
                    return new King(brd, Color.White);
                default: throw new ApplicationException($"Invalid piece \"{pieceChar}\"");
            }
        }
        public abstract string Image();

    }
}
