using ChessConsole.ChessBoard;
using ChessConsole.ChessBoard.Pieces ;
using ChessConsole.ChessGame;
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
                game.LoadFen("rnbqkbnr/8/4p3/p2p4/8/4P3/2PP4/RNBQKBNR w KQkq - 0 1");
                while (true)
                {
                    Console.Clear();
                    View.PrintBoard(game.Board);
                    Console.Write("Origin: ");
                    Position orig = Position.Parse(Console.ReadLine());

                    Piece? piece = game.GetPiece(orig);
                    List<Position> moves = null;
                    if (piece != null)
                    {
                        moves = piece.PseudoMoves();

                        Console.Clear();
                        View.PrintBoard(game.Board, MoveUtils.Translate(moves));
                        Console.Write("Destiny: ");
                        Position dest = Position.Parse(Console.ReadLine());

                        game.MakeMove(orig, dest);
                    }
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