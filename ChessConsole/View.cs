using ChessConsole.ChessBoard;
using ChessConsole.ChessBoard.Enums;

namespace ChessConsole
{
    namespace ChessConsole
    {
        class View
        {
            public static void PrintBoard(Board board)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                bool light = true;
                for (int i = 0; i < 8; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{8 - i} ");
                    for (int j = 0; j < 8; j++)
                    {
                        Piece p = board.Pieces[7 - i, j];

                        if (light) Console.BackgroundColor = ConsoleColor.DarkGray;
                        else Console.BackgroundColor = ConsoleColor.DarkGreen;

                        if (p == null)
                            Console.Write("  ");
                        else
                        {
                            Console.ForegroundColor = p.Color == Color.White ? ConsoleColor.White : ConsoleColor.Black;
                            Console.Write($"{p.Image()} ");
                        }
                        light = !light;
                    }
                    light = !light;
                    Console.WriteLine();
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  A B C D E F G H");
                Console.ResetColor();
            }
        }

    }
}
