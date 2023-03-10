using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard.Pieces
{
    internal class Rook : Piece
    {
        public Rook(Color color) : base(color)
        {
        }

        public override char Symbol => 'R';
        public override int Value => 5;
        public override int Sorter => 4;

        public override string Image()
        {
            return "\u265c";
            //return "R";
        }
        public override List<Move> Moves()
        {
            List<Position> pseudoMoves = new List<Position>();

            pseudoMoves.AddRange(Utils.Slide(this, 1, 0));
            pseudoMoves.AddRange(Utils.Slide(this, -1, 0));
            pseudoMoves.AddRange(Utils.Slide(this, 0, 1));
            pseudoMoves.AddRange(Utils.Slide(this, 0, -1));


            List<Move> moves = new List<Move>();
            foreach (Position pos in pseudoMoves)
            {
                Piece? target = Board.Get(pos);
                Move move = new Move(Position,
                    pos,
                    this,
                    target,
                    MoveType.Commun);

                if (move.TestMove())
                    moves.Add(move);
            }
            return moves;
        }
    }
}
