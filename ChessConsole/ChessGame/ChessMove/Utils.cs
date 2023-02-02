using ChessConsole.ChessGame.ChessBoard;
using ChessConsole.ChessGame.ChessBoard.Pieces;

namespace ChessConsole.ChessGame.ChessMove
{
    static class Utils
    {
        public static List<Position> Slide(Piece piece, int vertical, int horizontal)
        {
            List<Position> result = new List<Position>();
            int rank = piece.Position.Rank + vertical;
            int file = piece.Position.File + horizontal;

            while (Position.ValidPosition(file, rank) && Board.Get(rank, file) == null)
            {
                result.Add(new(file, rank));
                rank += vertical;
                file += horizontal;
            }

            if (Position.ValidPosition(file, rank) && Board.Get(rank, file).Color != piece.Color)
                result.Add(new(file, rank));

            return result;
        }
        public static bool SliderAtacker(Piece king, int vertical, int horizontal)
        {
            List<Position> ray = Slide(king, vertical, horizontal);
            if(ray.Count == 0) return false;

            Piece? att = Board.Get(ray.Last());
            if(att == null) return false;
            if (att is Queen) return true;

            return (vertical == 0 || horizontal == 0) ? (att is Rook) : (att is Bishop);
        }
        public static List<Position> KnightJumps(Piece knight)
        {
            int r, f;
            List<Position> result = new List<Position>();
            if (knight.CanGoTo(f = knight.Position.File - 1, r = knight.Position.Rank - 2))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File - 1, r = knight.Position.Rank + 2))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File + 1, r = knight.Position.Rank - 2))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File + 1, r = knight.Position.Rank + 2))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File - 2, r = knight.Position.Rank - 1))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File - 2, r = knight.Position.Rank + 1))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File + 2, r = knight.Position.Rank - 1))
                result.Add(new(f, r));
            if (knight.CanGoTo(f = knight.Position.File + 2, r = knight.Position.Rank + 1))
                result.Add(new(f, r));

            return result;
        }

        public static List<Position> KingWalk(Piece king)
        {
            int r, f;
            List<Position> result = new List<Position>();
            if (king.CanGoTo(f = king.Position.File - 1, r = king.Position.Rank - 1))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File - 1, r = king.Position.Rank))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File - 1, r = king.Position.Rank + 1))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File, r = king.Position.Rank - 1))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File, r = king.Position.Rank + 1))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File + 1, r = king.Position.Rank - 1))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File + 1, r = king.Position.Rank))
                result.Add(new(f, r));
            if (king.CanGoTo(f = king.Position.File + 1, r = king.Position.Rank + 1))
                result.Add(new(f, r));

            return result;
        }

        public static bool[,] Translate(List<Move> list)
        {
            bool[,] result = new bool[8, 8];

            foreach (Move move in list)
                result[move.To.Rank, move.To.File] = true;

            return result;
        }
    }
}
