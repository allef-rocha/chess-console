using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard.Pieces
{
    internal class King : Piece
    {
        public King(Color color) : base(color)
        {
        }

        public override char Symbol => 'K';

        public override string Image()
        {
            return "\u265a";
            //return "K";
        }

        public override List<Move> Moves()
        {
            List<Move> moves = new List<Move>();

            Move move;

            foreach (Position pos in Utils.KingWalk(this))
            {
                Piece? target = Board.Get(pos);
                move = new Move(
                    Position,
                    pos,
                    this,
                    target,
                    target != null ? MoveType.Capture : MoveType.Commun
                    );

                if (move.TestMove())
                    moves.Add(move);

            }
            if (Game.IsInCheck()) return moves;

            bool attacked = false;
            Position step;

            bool castleKing, castleQueen;
            int rank;


            if (Color == Color.White)
            {
                castleKing = Game.WhiteCastleKing;
                castleQueen = Game.WhiteCastleQueen;
                rank = 0;
            }
            else
            {
                castleKing = Game.BlackCastleKing;
                castleQueen = Game.BlackCastleQueen;
                rank = 7;
            }

            if (castleKing && Board.Get(rank, 5) == null && Board.Get(rank, 6) == null)
            {
                move = new Move(
                    Position,
                    new(5, rank),
                    this,
                    null,
                    MoveType.Commun);

                attacked |= !move.TestMove();

                move = new Move(
                    Position,
                    new(6, rank),
                    this,
                    null,
                    MoveType.Commun);

                attacked |= !move.TestMove();

                if (!attacked)
                {
                    move = new Move(
                        Position,
                        new(6, rank),
                        this,
                        null,
                        MoveType.CastleKing
                        );
                    moves.Add(move);
                }
            }
            attacked = false;
            if (castleQueen && Board.Get(rank, 2) == null && Board.Get(rank, 3) == null)
            {
                move = new Move(
                    Position,
                    new(3, rank),
                    this,
                    null,
                    MoveType.Commun);

                attacked |= !move.TestMove();

                move = new Move(
                    Position,
                    new(2, rank),
                    this,
                    null,
                    MoveType.Commun);

                attacked |= !move.TestMove();

                if (!attacked)
                {
                    move = new Move(
                        Position,
                        new(2, rank),
                        this,
                        null,
                        MoveType.CastleQueen
                        );
                    moves.Add(move);
                }
            }
            return moves;
        }

    }
}
