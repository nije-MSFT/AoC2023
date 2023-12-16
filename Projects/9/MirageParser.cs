using System.Xml.Linq;

namespace AoC2023_9
{
    internal class MirageParser
    {
        public int NextNumber { get; }

        public int PreviousNumber { get; }

        public MirageParser(string line)
        {
            var numbers = line.Split(' ').Select(x => int.Parse(x));

            NextNumber = FindNextNumber(numbers.ToArray());
            PreviousNumber = FindNextNumber(numbers.Reverse().ToArray());
        }

        private int FindNextNumber(int[] numbers)
        {
            var current = numbers[0];
            var differences = new List<int>();

            for (int i = 1; i < numbers.Length; i++)
            {
                differences.Add(numbers[i] - current);
                current = numbers[i];
            }

            return differences.All(x => x == 0) ?
                current :
                current + FindNextNumber(differences.ToArray());
        }
    }
}
