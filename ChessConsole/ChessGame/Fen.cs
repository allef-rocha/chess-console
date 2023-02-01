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
            bool wking = false;
            bool bking = false;

            string[] ranks = board.Split("/");
            foreach (string rank in ranks)
            {
                int count = 0;
                foreach (char val in rank)
                {
                    if (val >= '1' && val <= '8')
                    {
                        count += val - '0';
                        continue;
                    }
                    count++;

                    if (val == 'k') if (bking) return false; else bking = true;
                    else
                    if (val == 'K') if (wking) return false; else wking = true;
                }
                if (count != 8) return false;
            }
            return wking && bking;
        }
        public static bool ValidFen(string fen)
        {
            Match m = FenRegex.Match(fen);

            if (!m.Success) return false;

            return ValidBoard(m.Groups[1].Value);
        }
    }
}
