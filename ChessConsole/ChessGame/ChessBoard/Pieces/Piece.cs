using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard.Pieces
{
    abstract class Piece
    {
        public abstract char Symbol { get; }
        public Color Color { get; set; }
        public Position? Position { get; set; }

        public Piece(Color color)
        {
            Color = color;
            Position = null;
        }

        public bool CanGoTo(int file, int rank)
        {
            return Position.ValidPosition(file, rank)
                && (Board.Get(rank, file) == null || Board.Get(rank, file).Color != Color);
        }
        public static Piece Parse(char pieceChar)
        {
            switch (pieceChar)
            {
                case 'p':
                    return new Pawn(Color.Black);
                case 'n':
                    return new Knight(Color.Black);
                case 'b':
                    return new Bishop(Color.Black);
                case 'r':
                    return new Rook(Color.Black);
                case 'q':
                    return new Queen(Color.Black);
                case 'k':
                    return new King(Color.Black);
                case 'P':
                    return new Pawn(Color.White);
                case 'N':
                    return new Knight(Color.White);
                case 'B':
                    return new Bishop(Color.White);
                case 'R':
                    return new Rook(Color.White);
                case 'Q':
                    return new Queen(Color.White);
                case 'K':
                    return new King(Color.White);
                default: throw new ApplicationException($"Invalid piece \"{pieceChar}\"");
            }
        }
        public abstract string Image();

        public abstract List<Move> Moves();

    }
}
