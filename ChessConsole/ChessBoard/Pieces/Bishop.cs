using ChessConsole.ChessBoard.Enums;
using System.Linq;

namespace ChessConsole.ChessBoard.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color) : base(color)
        {
        }

        public override string Image()
        {
            return "\u265d";
            //return "B";
        }

        public override List<Position> PseudoMoves()
        {
            List<Position> allMoves = new List<Position>();
            allMoves.AddRange(MoveUtils.Slide(this, 1, 1));
            allMoves.AddRange(MoveUtils.Slide(this, 1, -1));
            allMoves.AddRange(MoveUtils.Slide(this, -1, 1));
            allMoves.AddRange(MoveUtils.Slide(this, -1, -1));
            return allMoves;
        }
    }
}