using ChessConsole.ChessBoard;
using System.Text.RegularExpressions;

namespace ChessConsole.ChessGame
{
    internal class Fen
    {
        private static readonly string _fenPattern = @"^\s*((?:[pnbrqkPNBRQK1-8]{1,8}/){7}[pnbrqkPNBRQK1-8]{1,8})\s+([bw])\s+(K?Q?k?q?|-)\s+([a-h][1-8]|-)\s+(0|[1-9][0-9]*)\s+([1-9][0-9]*)\s*$";

        public static Regex FenRegex = new(_fenPattern);
        private static bool ValidBoard(string board)
        {
            string[] ranks = board.Split("/");
            foreach (string rank in ranks)
            {
                int count = 0;
                foreach (char val in rank)
                {
                    if (val >= '1' && val <= '8')
                        count += val - '0';
                    else
                        count++;
                }
                if (count != 8) return false;
                
            }
            return true;
        }
        public static bool ValidFen(string fen)
        {
            Match m = FenRegex.Match(fen);

            if (!m.Success) return false;

            return ValidBoard(m.Groups[1].Value);
        }
    }
}
