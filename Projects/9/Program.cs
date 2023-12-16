using System.Xml.Linq;

namespace AoC2023_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");

            int totalPart1 = 0;
            int totalPart2 = 0;

            foreach (var line in inputLines)
            {
                var parser = new MirageParser(line);
                totalPart1 += parser.NextNumber;
                totalPart2 += parser.PreviousNumber;
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }
    }
}
