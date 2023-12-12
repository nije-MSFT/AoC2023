using System.Diagnostics;

namespace AoC2023_1
{
    internal class Program
    {
        static Dictionary<string, int> WordNumbers = new Dictionary<string, int>()
        {
            {"1", 1 },
            {"one", 1 },
            {"2", 2 },
            {"two", 2 },
            {"3", 3 },
            {"three", 3 },
            {"4", 4 },
            {"four", 4 },
            {"5", 5 },
            {"five", 5 },
            {"6", 6 },
            {"six", 6 },
            {"7", 7 },
            {"seven", 7 },
            {"8", 8 },
            {"eight", 8 },
            {"9", 9 },
            {"nine", 9 },
        };

        static void Main(string[] args)
        {
            var totalPart1 = 0;
            var totalPart2 = 0;

            foreach (string line in File.ReadAllLines(".\\Input.txt"))
            {
                totalPart1 += FindFirst(line) + FindLast(line);
                totalPart2 += FindFirstWithWords(line) + FindLastWithWords(line);
            }

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }

        static int FindFirstWithWords(string line)
        {
            for (int pos = 0; pos < line.Length; pos++)
            {
                var wordNumber = FindWordNumberAtPosition(line, pos);
                if (wordNumber.HasValue)
                {
                    return wordNumber.Value * 10;
                }
            }

            throw new Exception("Did not find number");
        }

        static int FindLastWithWords(string line)
        {
            for (int pos = line.Length - 1; pos >= 0; pos--)
            {
                var wordNumber = FindWordNumberAtPosition(line, pos);
                if (wordNumber.HasValue)
                {
                    return wordNumber.Value;
                }
            }

            throw new Exception("Did not find number");
        }

        static int? FindWordNumberAtPosition(string line, int position)
        {
            for (int length = 1; length <= 5; length++)
            {
                if (line.Length - position >= length)
                {
                    var substr = line.Substring(position, length);

                    if (WordNumbers.ContainsKey(substr))
                    {
                        return WordNumbers[substr];
                    }
                }
            }

            return null;
        }

        static int FindFirst(string line)
        {
            for (int pos = 0; pos < line.Length; pos++)
            {
                if (line[pos] >= '0' && line[pos] <= '9')
                {
                    return (line[pos] - 48) * 10;
                }
            }

            throw new Exception("Did not find number");
        }

        static int FindLast(string line)
        {
            for (int pos = line.Length - 1; pos >= 0; pos--)
            {
                if (line[pos] >= '0' && line[pos] <= '9')
                {
                    return (line[pos] - 48);
                }
            }

            throw new Exception("Did not find number");
        }
    }
}
