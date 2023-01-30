namespace ChessConsole.ChessBoard
{
    class Board
    {
        public Piece?[,] Pieces;

        private Board()
        {
            Pieces = new Piece[8, 8];

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

        public Piece? RemovePiece(Position position)
        {
            Piece? piece = Pieces[position.Rank, position.File];
            if (piece == null)
            {
                return piece;
            }
            Pieces[position.Rank, position.File] = null;
            return piece;
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (Pieces[position.Rank, position.File] != null)
            {
                throw new ArgumentException("Position occuped.");
            }
            Pieces[position.Rank, position.File] = piece;
        }
    }
}
