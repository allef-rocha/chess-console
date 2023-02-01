using ChessConsole.ChessBoard.Enums;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Queen : Piece
    {
        public Queen(Color color) : base(color)
        {
        }
        public override string Image()
        {
            return "\u265b";
            //return "Q";
        }
        public override List<Position> PseudoMoves()
        {
            List<Position> allMoves = new List<Position>();


            allMoves.AddRange(MoveUtils.Slide(this, 1, 0));
            allMoves.AddRange(MoveUtils.Slide(this, -1, 0));
            allMoves.AddRange(MoveUtils.Slide(this, 0, 1));
            allMoves.AddRange(MoveUtils.Slide(this, 0, -1));
            allMoves.AddRange(MoveUtils.Slide(this, 1, 1));
            allMoves.AddRange(MoveUtils.Slide(this, 1, -1));
            allMoves.AddRange(MoveUtils.Slide(this, -1, 1));
            allMoves.AddRange(MoveUtils.Slide(this, -1, -1));

            return allMoves;
        }
    }
}
