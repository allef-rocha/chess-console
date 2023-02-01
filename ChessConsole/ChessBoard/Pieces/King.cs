using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class King : Piece
    {
        public King(Color color) : base(color)
        {
        }

        public override string Image()
        {
            return "\u265a";
            //return "K";
        }

        public override List<Position> PseudoMoves()
        {
            int r, f;
            List<Position> result = new List<Position>();
            if (CanGoTo(f = Position.File - 1, r = Position.Rank - 1))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File - 1, r = Position.Rank))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File - 1, r = Position.Rank + 1))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File, r = Position.Rank - 1))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File, r = Position.Rank + 1))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File + 1, r = Position.Rank - 1))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File + 1, r = Position.Rank))
                result.Add(new(f, r));
            if (CanGoTo(f = Position.File + 1, r = Position.Rank + 1))
                result.Add(new(f, r));

            return result;
        }
    }
}
