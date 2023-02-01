namespace ChessConsole.ChessBoard.Pieces
{
    static class MoveUtils
    {
        public static List<Position> Slide(Piece piece, int vertical, int horizontal)
        {
            List<Position> result = new List<Position>();
            int rank = piece.Position.Rank + vertical;
            int file = piece.Position.File + horizontal;

            while (Position.ValidPosition(file, rank) && Piece.Board.Pieces[rank, file] == null)
            {
                result.Add(new(file, rank));
                rank += vertical;
                file += horizontal;
            }

            if (Position.ValidPosition(file, rank) && Piece.Board.Pieces[rank, file].Color != piece.Color)
                result.Add(new(file, rank));

            return result;
        }
        public static bool[,] Translate(List<Position> list)
        {
            bool[,] result = new bool[8, 8];

            foreach (Position pos in list)
                result[pos.Rank, pos.File] = true;

            return result;
        }
    }
}
