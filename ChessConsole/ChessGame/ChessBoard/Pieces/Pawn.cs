using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessBoard.Pieces
{
    internal class Pawn : Piece
    {
        public Pawn(Color color) : base(color)
        {
        }

        public override char Symbol => 'P';
        public override int Value => 1;
        public override int Sorter => 1;

        public override string Image()
        {
            return "\u265f";
            //return "P";
        }

        public override List<Move> Moves()
        {
            List<Move> moves = new List<Move>();

            int rank = Position.Rank, file = Position.File,
                firstRank, lastRank, deltaRank;

            if (Color == Color.White)
            {
                firstRank = 1; lastRank = 7; deltaRank = 1;
            }
            else
            {
                firstRank = 6; lastRank = 0; deltaRank = -1;
            }

            Move move;
            if (Board.Get(rank = rank + deltaRank, file) == null)
            {
                move = new Move(Position,
                    new(file, rank),
                    this,
                    null,
                    rank == lastRank ? MoveType.Promotion : MoveType.Commun);
                moves.Add(move);
                if (Position.Rank == firstRank && Board.Get(rank = rank + deltaRank, file) == null)
                {
                    move = new Move(Position,
                    new(file, rank),
                    this,
                    null,
                    MoveType.DoubleStep);
                    moves.Add(move);
                }
            }
            Piece? target;
            Position targetPos;

            if (Position.ValidPosition(file = Position.File - 1, rank = Position.Rank + deltaRank))
            {
                if ((target = Board.Get(rank, file)) != null && target.Color != Color)
                {
                    move = new Move(Position,
                        new(file, rank),
                        this,
                        target,
                        rank == lastRank ? MoveType.Promotion : MoveType.Commun);
                    moves.Add(move);
                }
                else if (Game.EnPassant != null && Game.EnPassant.Rank == rank && Game.EnPassant.File == file)
                {
                    move = new Move(Position,
                            new(file, rank),
                            this,
                            Board.Get(Position.Rank, file),
                            MoveType.EnPassant);
                    moves.Add(move);

                }
            }
            if (Position.ValidPosition(file = Position.File + 1, rank = Position.Rank + deltaRank))
            {
                if ((target = Board.Get(rank, file)) != null && target.Color != Color)
                {
                    move = new Move(Position,
                        new(file, rank),
                        this,
                        target,
                        rank == lastRank ? MoveType.Promotion : MoveType.Commun);
                    moves.Add(move);
                }
                if (Game.EnPassant != null && Game.EnPassant.Rank == rank && Game.EnPassant.File == file)
                {
                    move = new Move(Position,
                            new(file, rank),
                            this,
                            Board.Get(Position.Rank, file),
                            MoveType.EnPassant);
                    moves.Add(move);
                }
            }

            return moves.Where(move => move.TestMove()).ToList();
        }
    }
}
