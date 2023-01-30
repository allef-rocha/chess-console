using ChessConsole.ChessBoard;
using ChessConsole.ChessBoard.Enums;
using System.Text.RegularExpressions;

namespace ChessConsole.ChessGame
{

    internal class Game
    {
        private static Game? _instance;
        public Board Board { get; set; }

        public Color Turn;
        public bool WhiteKingCastle { get; private set; }
        public bool WhiteQueenCastle { get; private set; }
        public bool BlackKingCastle { get; private set; }
        public bool BlackQueenCastle { get; private set; }
        public Position? EnPassant { get; private set; }
        public int MoveCount { get; private set; }
        public int ClockCount { get; private set; }

        private Game()
        {
            Board = Board.GetInstance();
            Turn = Color.White;
            WhiteKingCastle = true;
            WhiteQueenCastle = true;
            BlackKingCastle = true;
            BlackQueenCastle = true;
            EnPassant = null;
            MoveCount = 1;
            ClockCount = 0;
        }

        public static Game GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
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
                    Piece piece = Piece.Parse(pieceChar, Board);
                    Board.PutPiece(piece, new(file, rank));
                    file++;
                }
                rank--;
            }

            Turn = turn[0] == 'w' ? Color.White : Color.Black;

            WhiteKingCastle = castles.Contains('K');
            WhiteQueenCastle = castles.Contains('Q');
            BlackKingCastle = castles.Contains('k');
            BlackQueenCastle = castles.Contains('q');

            EnPassant = Position.Parse(enpassant);

            MoveCount = int.Parse(moves);
            ClockCount = int.Parse(clock);

        }
    }
}
