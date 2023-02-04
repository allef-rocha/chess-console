using ChessConsole.ChessGame.ChessBoard.Pieces;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard
{
    class Board
    {
        private static Piece?[,] Pieces = new Piece[8, 8];

        private Board()
        {
        }

        private static Board? _instance;

        public static Board GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Board();
            }
            return _instance;
        }

        public static void Set(int rank, int file, Piece? piece)
        {
            if (!Position.ValidPosition(file, rank)) return;
            Pieces[rank, file] = piece;
            if (piece != null) piece.Position = new Position(file, rank);
        }
        public static void Set(Position pos, Piece? piece)
        {
            Pieces[pos.Rank, pos.File] = piece;
            if (piece != null) piece.Position = pos;
        }
        public static Piece? Get(int rank, int file)
        {
            if (!Position.ValidPosition(file, rank)) return null;
            return Pieces[rank, file];
        }
        public static Piece? Get(Position? pos)
        {
            if (pos == null) return null;
            return Pieces[pos.Rank, pos.File];
        }

        public static void Force(Position? pos, Piece? piece)
        {
            if (pos == null) return;
            Pieces[pos.Rank, pos.File] = piece;
            piece.Position = pos;
        }
        public static void Force(int rank, int file, Piece? piece)
        {
            if (!Position.ValidPosition(file, rank)) return;
            Pieces[rank, rank] = piece;
            piece.Position = new(file, rank);
        }

        public static bool InsufficientMaterial()
        {
            int knights = 0;
            int bishopsA = 0;
            int bishopsB = 0;
            int color = 0;
            int count = 0;
            foreach (var piece in Pieces)
            {
                color++;
                count++;
                bool light = color % 2 == 0;
                if (count % 8 == 0)
                {
                    color++;
                }
                if (piece == null) continue;

                if (piece is Knight)
                    knights++;
                else if (piece is Bishop)
                {
                    if (light)
                        bishopsA++;
                    else
                        bishopsB++;
                }
                else if (piece is not King)
                    return false;
            }
            if (knights > 1) return false;
            if (knights == 1 && bishopsA + bishopsB > 0) return false;
            if (bishopsA > 0 && bishopsB > 0) return false;
            return true;

        }


    }
}
