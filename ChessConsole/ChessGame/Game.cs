using ChessConsole.ChessGame.ChessBoard;
using ChessConsole.ChessGame.ChessBoard.Pieces;
using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;
using System.Text.RegularExpressions;

namespace ChessConsole.ChessGame
{

    internal class Game
    {
        private static Game? _instance;
        public Board Board { get; set; }

        public static Color Turn;

        public static King WhiteKing { get; set; }
        public static King BlackKing { get; set; }
        public static bool WhiteCastleKing { get; private set; }
        public static bool WhiteCastleQueen { get; private set; }
        public static bool BlackCastleKing { get; private set; }
        public static bool BlackCastleQueen { get; private set; }
        public static Position? EnPassant { get; private set; }
        public static int MoveCount { get; private set; }
        public static int ClockCount { get; private set; }

        private Game()
        {
            Board = Board.GetInstance();
        }

        public static Game GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }

        public Piece? MakeMove(Move move)
        {
            Piece? captured = null;
            bool castleKing = true,
                castleQueen = true,
                otherCastleQueen = true,
                otherCastleKing = true;

            int foward, firstRank, lastRank;
            if (Turn == Color.White)
            {
                foward = 1;
                firstRank = 0;
                lastRank = 7;
            }
            else
            {
                foward = -1;
                firstRank = 7;
                lastRank = 0;
            }
            move.DoMove();

            EnPassant = null;
            switch (move.MoveType)
            {
                case MoveType.Capture:
                case MoveType.EnPassant:
                    captured = move.Target;
                    ClockCount = 0;
                    break;
                case MoveType.DoubleStep:
                    EnPassant = new(move.From.File, move.From.Rank + foward);
                    break;
                default:
                    break;
            }
            switch (move.Piece.Symbol)
            {
                case 'K':
                    castleKing = false;
                    castleQueen = false;
                    break;
                case 'R':
                    if (move.From.File == 0 && move.From.Rank == firstRank)
                        castleQueen = false;
                    else if (move.From.File == 7 && move.From.Rank == firstRank)
                        castleKing = false;
                    break;
                case 'P':
                    ClockCount = 0;
                    break;
                default:
                    break;
            }

            if (move.To.File == 0 && move.To.File == lastRank)
                otherCastleQueen = false;
            else if (move.To.File == 7 && move.To.File == lastRank)
                otherCastleKing = false;

            if (Turn == Color.White)
            {
                WhiteCastleKing &= castleKing;
                WhiteCastleQueen &= castleQueen;
                BlackCastleKing &= otherCastleKing;
                BlackCastleQueen &= otherCastleQueen;
                Turn = Color.Black;
            }
            else
            {
                BlackCastleKing &= castleKing;
                BlackCastleQueen &= castleQueen;
                WhiteCastleKing &= otherCastleKing;
                WhiteCastleQueen &= otherCastleQueen;
                Turn = Color.White;
            }
            return captured;
        }

        public void LoadFen(string fen)
        {
            if (!Fen.ValidFen(fen)) throw new ApplicationException("Invalid Fen");

            Match m = Fen.FenRegex.Match(fen);
            IEnumerable<string> data = m.Groups.Cast<Group>().Skip(1).Where(o => o.Value != "").Select(o => o.Value);

            string board = data.ElementAt(0);
            string turn = data.ElementAt(1);
            string castles = data.ElementAt(2);
            string enpassant = data.ElementAt(3);
            string moves = data.ElementAt(4);
            string clock = data.ElementAt(5);

            int file, rank = 7;
            foreach (string srank in board.Split("/"))
            {
                file = 0;
                foreach (char pieceChar in srank)
                {
                    if (pieceChar >= '1' && pieceChar <= '8')
                    {
                        file += pieceChar - '0';
                        continue;
                    }
                    Piece? piece = Piece.Parse(pieceChar);
                    if (piece != null)
                    {
                        Board.Set(rank, file, piece);
                        if (piece is King)
                        {
                            if (piece.Color == Color.White)
                                WhiteKing = piece as King;
                            else
                                BlackKing = piece as King;
                        }
                    }
                    file++;
                }
                rank--;
            }

            Turn = turn[0] == 'w' ? Color.White : Color.Black;

            WhiteCastleKing = castles.Contains('K');
            WhiteCastleQueen = castles.Contains('Q');
            BlackCastleKing = castles.Contains('k');
            BlackCastleQueen = castles.Contains('q');

            EnPassant = Position.Parse(enpassant);

            MoveCount = int.Parse(moves);
            ClockCount = int.Parse(clock);

        }

        public static bool IsInCheck()
        {
            King king = Turn == Color.White ? WhiteKing : BlackKing;
            Piece? piece;
            if (Utils.SliderAtacker(king, 1, 0)) return true;
            if (Utils.SliderAtacker(king, -1, 0)) return true;
            if (Utils.SliderAtacker(king, 0, 1)) return true;
            if (Utils.SliderAtacker(king, 0, -1)) return true;
            if (Utils.SliderAtacker(king, 1, 1)) return true;
            if (Utils.SliderAtacker(king, 1, -1)) return true;
            if (Utils.SliderAtacker(king, -1, 1)) return true;
            if (Utils.SliderAtacker(king, -1, -1)) return true;

            foreach (var pos in Utils.KingWalk(king))
            {
                if (Board.Get(pos) is King) return true;
            }
            foreach (var pos in Utils.KnightJumps(king))
            {
                if (Board.Get(pos) is Knight) return true;
            }

            int deltaRank = Turn == Color.White ? 1 : -1;
            Piece? pawn;

            pawn = Board.Get(king.Position.Rank + deltaRank, king.Position.File + 1);
            if (pawn is Pawn && pawn.Color != Turn) return true;

            pawn = Board.Get(king.Position.Rank + deltaRank, king.Position.File - 1);
            if (pawn is Pawn && pawn.Color != Turn) return true;

            return false;
        }

        public Piece? GetPiece(Position pos)
        {
            return Board.Get(pos);
        }
    }
}
