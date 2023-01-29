using ChessConsole.ChessBoard;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board board = Board.GetInstance();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("---------------------");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}