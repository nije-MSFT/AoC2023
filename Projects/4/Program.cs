namespace AoC2023_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");

            var totalPart1 = 0;
            var totalPart2 = 0;

            foreach (var line in inputLines)
            {
                var cardNumberAndOtherNumbers = line.Split(':');
                
                var playerNumbersAndWinningNumbers = cardNumberAndOtherNumbers[1].Split('|');
                
                var card = new Card(
                    int.Parse(cardNumberAndOtherNumbers[0].Split(' ').Last()),
                    playerNumbersAndWinningNumbers[0].Split(' ').Where(x => x != string.Empty).Select(x => int.Parse(x)));

                totalPart1 += card.GetCardValue(playerNumbersAndWinningNumbers[1].Split(' ').Where(x => x != string.Empty).Select(x => int.Parse(x)));
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }
    }
}
