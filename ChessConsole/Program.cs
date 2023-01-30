using ChessConsole.ChessBoard;
using ChessConsole.ChessBoard.Enums;
using ChessConsole.ChessBoard.Pieces;
using ChessConsole.ChessConsole;
using ChessConsole.ChessGame;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = Game.GetInstance();
                game.LoadFen("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR b KQkq e3 0 1");
                View.PrintBoard(game.Board);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}