using ChessConsole.ChessGame.ChessBoard.Pieces;

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
            if(pos == null) return null;
            return Pieces[pos.Rank, pos.File];
        }

    }
}
