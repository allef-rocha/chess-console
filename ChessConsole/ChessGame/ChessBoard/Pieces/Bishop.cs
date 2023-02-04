using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard.Pieces
{
    internal class Bishop : Piece
    {
        public Bishop(Color color) : base(color)
        {
        }

        public override char Symbol => 'B';
        public override int Value => 3;
        public override int Sorter => 3;

        public override string Image()
        {
            return "\u265d";
            //return "B";
        }

        public override List<Move> Moves()
        {
            List<Position> pseudoMoves = new List<Position>();
            pseudoMoves.AddRange(Utils.Slide(this, 1, 1));
            pseudoMoves.AddRange(Utils.Slide(this, 1, -1));
            pseudoMoves.AddRange(Utils.Slide(this, -1, 1));
            pseudoMoves.AddRange(Utils.Slide(this, -1, -1));


            List<Move> moves = new List<Move>();
            foreach (Position pos in pseudoMoves)
            {
                Piece? target = Board.Get(pos);
                Move move = new Move(Position,
                    pos,
                    this,
                    target,
                    MoveType.Commun);


                if(move.TestMove())
                    moves.Add(move);

            }
            return moves;
        }
    }
}