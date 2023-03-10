using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard.Pieces
{
    internal class Knight : Piece
    {
        public Knight(Color color) : base(color)
        {
        }

        public override char Symbol => 'N';
        public override int Value => 3;
        public override int Sorter => 2;

        public override string Image()
        {
            return "\u265e";
            //return "N";
        }
        public override List<Move> Moves()
        {
            List<Move> moves = new List<Move>();   

            foreach(Position pos in Utils.KnightJumps(this))
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
