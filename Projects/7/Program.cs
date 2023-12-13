namespace AoC2023_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var totalPart1 = 0;
            var totalPart2 = 0;

            var inputLines = File.ReadAllLines(".\\Input.txt");

            var allHands = new List<Hand>();

            foreach (var line in inputLines)
            {
                allHands.Add(new Hand(line));
            }

            var allRankedHands = allHands.OrderByDescending(x => x, new HandComparer()).ToArray();

            for (int i = 0 ; i < allRankedHands.Length; i++)
            {
                totalPart1 += allRankedHands[i].Wager * (allRankedHands.Length - i);
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }
    }
}
