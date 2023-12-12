namespace AoC2023_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var totalPart1 = 0;
            var totalPart2 = 0;

            foreach (string line in File.ReadAllLines(".\\Input.txt"))
            {
                var game = new GameResult(line);

                if (game.IsPossible(minRed: 12, minGreen: 13, minBlue: 14))
                {
                    totalPart1 += game.GameId;
                }

                totalPart2 += game.Power();
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }
    }
}
