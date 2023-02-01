using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color) : base(color)
        {
        }
        public override string Image()
        {
            return "\u265f";
            //return "P";
        }

        public override List<Position> PseudoMoves()
        {
            List<Position> result = new List<Position>();
            int rank = Position.Rank, file = Position.File;
            if (Board.Pieces[++rank, file] == null)
            {
                result.Add(new(file, rank));
            }
            return result;
        }
    }
}
