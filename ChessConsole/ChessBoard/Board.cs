namespace ChessConsole.ChessBoard
{
    class Board
    {
        public Piece[,] Pieces;

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
    }
}
