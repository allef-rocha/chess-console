using ChessConsole.ChessGame;
using ChessConsole.ChessGame.ChessBoard;
using ChessConsole.ChessGame.ChessBoard.Pieces;
using ChessConsole.ChessGame.ChessMove;
using ChessConsole.ChessGame.Enums;
using ChessConsole.ChessView;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = Game.GetInstance();
                //game.LoadFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
                //game.LoadFen("rnbqkbnr/pppppppp/8/8/7b/8/PPPPP2P/RNBQKBNR w KQkq - 0 1");
                game.LoadFen("r3k2r/p6p/1N6/6P1/8/8/8/4K2R b KQkq - 0 1");
                List<Move>[,] grid = new List<Move>[8, 8];

                for (int i = 0; i < grid.Length; i++) { grid[i / 8, i % 8] = new List<Move>(); }

                while (true)
                {
                    bool isMoves = false;
                    for (int rank = 0; rank < 8; rank++)
                    {
                        for (int file = 0; file < 8; file++)
                        {
                            grid[rank, file].Clear();

                            Piece? piece = Board.Get(rank, file);
                            if (piece == null || piece.Color != Game.Turn) continue;

                            grid[rank, file] = piece.Moves();

                            isMoves |= grid[rank, file].Count > 0;
                        }
                    }
                    Console.Clear();
                    View.PrintBoard();

                    Console.Write(Game.Turn == Color.White ? "WHITE" : "BLACK");
                    Console.WriteLine(" to play");

                    if (!isMoves)
                    {
                        Console.WriteLine("Check-mate!");
                        break;
                    }

                    Console.Write("Origin: ");
                    Position? orig = Position.Parse(Console.ReadLine() ?? "");
                    if (orig == null) continue;

                    List<Move>? moves = grid[orig.Rank, orig.File];
                    if (moves.Count == 0) continue;

                    Console.Clear();
                    View.PrintBoard(Utils.Translate(moves));

                    Console.Write("Destiny: ");
                    Position? dest = Position.Parse(Console.ReadLine() ?? "");
                    if (dest == null) continue;

                    Move? move = moves.Find(m => m.To.Rank == dest.Rank && m.To.File == dest.File);
                    if (move == null) continue;

                    Piece? captured = game.MakeMove(move);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}