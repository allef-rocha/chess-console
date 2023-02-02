using ChessConsole.ChessGame.ChessBoard;
using ChessConsole.ChessGame.ChessBoard.Pieces;
using ChessConsole.ChessGame.Enums;

namespace ChessConsole.ChessGame.ChessMove
{
    internal class Move
    {
        public Position From;
        public Position To;
        public Piece Piece;
        public Piece? Target;
        public MoveType MoveType;

        public Move(Position from, Position to, Piece piece, Piece? target, MoveType moveType)
        {
            From = from;
            To = to;
            Piece = piece;
            Target = target;
            MoveType = moveType;
        }

        public void DoMove()
        {
            Board.Set(To.Rank, To.File, Piece);
            Board.Set(From.Rank, From.File, null);
            switch (MoveType)
            {
                case MoveType.CastleKing:
                    Board.Set(To.Rank, 5, Board.Get(To.Rank, 7));
                    Board.Set(To.Rank, 7, null);
                    break;

                case MoveType.CastleQueen:
                    Board.Set(To.Rank, 3, Board.Get(To.Rank, 0));
                    Board.Set(To.Rank, 0, null);
                    break;
                case MoveType.EnPassant:
                    Board.Set(From.Rank, To.File, null);
                    break;
                default:
                    break;
            }
        }

        public void UndoMove()
        {
            Board.Set(From.Rank, From.File, Piece);

            switch (MoveType)
            {
                case MoveType.CastleKing:
                    Board.Set(To.Rank, To.File, null);
                    Board.Set(To.Rank, 7, Board.Get(To.Rank, 5));
                    Board.Set(To.Rank, 5, null);
                    break;
                case MoveType.CastleQueen:
                    Board.Set(To.Rank, To.File, null);
                    Board.Set(To.Rank, 0, Board.Get(To.Rank, 3));
                    Board.Set(To.Rank, 3, null);
                    break;
                case MoveType.EnPassant:
                    Board.Set(To.Rank, To.File, null);
                    Board.Set(From.Rank, To.File, Target);
                    break;
                default:
                    Board.Set(To.Rank, To.File, Target);
                    break;

            }
        }
        public bool TestMove()
        {
            DoMove();

            bool valid = !Game.IsInCheck();

            UndoMove();

            return valid;
        }
    }

}
