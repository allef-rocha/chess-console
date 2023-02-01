using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Color color) : base(color)
        {
        }

        public override string Image()
        {
            return "\u265e";
            //return "N";
        }
        public override List<Position> PseudoMoves()
        {
            int r, f;
            List<Position> result = new List<Position>();
            if (CanGoTo(f = Position.File - 1, r = Position.Rank - 2))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File - 1, r = Position.Rank + 2))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File + 1, r = Position.Rank - 2))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File + 1, r = Position.Rank + 2))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File - 2, r = Position.Rank - 1))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File - 2, r = Position.Rank + 1))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File + 2, r = Position.Rank - 1))
                result.Add(new(f,r));
            if (CanGoTo(f = Position.File + 2, r = Position.Rank + 1))
                result.Add(new(f,r));

            return result;
        }
    }
}
