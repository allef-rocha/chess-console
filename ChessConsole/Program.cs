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
                game.LoadFen("8/8/8/8/6b1/6kn/8/7K b - - 0 1");
                //game.LoadFen("rnbqkbnr/2p2p2/8/pp1Pp1pp/P1Pp1PP1/8/1P2P2P/RNBQKBNR w KQkq - 0 1");
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
                            if (piece == null) continue;

                            if (piece.Color != Game.Turn)
                                continue;

                            grid[rank, file] = piece.Moves();

                            isMoves |= grid[rank, file].Count > 0;
                        }
                    }

                    View.PrintBoard();

                    if (!isMoves || Board.InsufficientMaterial())
                    {
                        break;
                    }

                    Console.Write("Origin: ");
                    Position? orig = Position.Parse(Console.ReadLine() ?? "");
                    if (orig == null) continue;

                    List<Move>? moves = grid[orig.Rank, orig.File];
                    if (moves.Count == 0) continue;

                    View.PrintBoard(Utils.Translate(moves));

                    Console.Write("Destiny: ");
                    Position? dest = Position.Parse(Console.ReadLine() ?? "");
                    if (dest == null) continue;

                    Move? move = moves.Find(m => m.To.Rank == dest.Rank && m.To.File == dest.File);
                    if (move == null) continue;

                    Color color = Game.Turn;
                    int eval = Game.Turn == Color.White ? 1 : -1;

                    Piece? captured = game.MakeMove(move);

                    if (move.MoveType == MoveType.Promotion)
                    {
                        Console.Write("Promote to [Q/R/B/N] (default Q): ");
                        string promote = Console.ReadLine() ?? "";
                        if (promote == "")
                            promote = "Q";
                        Piece piece;
                        switch (promote.Trim().ToUpper()[0])
                        {
                            case 'R':
                                piece = new Rook(color);
                                break;
                            case 'B':
                                piece = new Bishop(color);
                                break;
                            case 'N':
                                piece = new Knight(color);
                                break;
                            default:
                                piece = new Queen(color);
                                break;
                        }
                        Board.Force(move.To, piece);

                        Game.Eval += eval * (piece.Value - 1);
                    }
                }
                if (Board.InsufficientMaterial())
                {
                    Console.WriteLine("Draw by insufficient material");
                }
                else if (Game.IsInCheck())
                {
                    if (Game.Turn == Color.White)
                        Console.WriteLine("Checkmate! Black wins");
                    else
                        Console.WriteLine("Checkmate! White wins");
                }
                else
                {
                    Console.WriteLine("Draw due to Stalemate");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.Read();
        }
    }
}