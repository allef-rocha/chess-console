namespace ChessConsole.ChessBoard
{
    internal class Position
    {
        public int File { get; set; }
        public int Rank { get; set; }

        public Position(int file, int rank)
        {
            if (!ValidPosition(file, rank))
                throw new ArgumentException("Rank and file index must be in range [0-7]");

            File = file;
            Rank = rank;
        }
        public static Position? Parse(string position)
        {
            if (!ValidPosition(position))
                return null;

            return new Position(position[0] - 'a', position[1] - '1');
        }

        private static bool ValidPosition(string position)
        {
            return position.Length == 2
                && position[0] >= 'a'
                && position[0] <= 'h'
                && position[1] >= '1'
                && position[1] <= '8';

        }
        public static bool ValidPosition(int file, int rank)
        {
            return file >= 0
                && file <= 7
                && rank >= 0
                && rank <= 7;
        }
        public override string ToString()
        {
            return $"{(char)('a' + File)}{Rank + 1}";
        }
    }
}
