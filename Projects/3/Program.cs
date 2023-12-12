using System.Collections.Specialized;
using System.Text;

namespace AoC2023_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");

            Line previousLine = new Line();
            Line currentLine = ParseLine(inputLines[0]);
            Line nextLine = ParseLine(inputLines[1]);

            int lineNumber = 1;

            var totalPart1 = 0;
            var totalPart2 = 0;

            while (nextLine != null)
            {
                totalPart1 += GetPartNumbersInLine(previousLine, currentLine, nextLine);

                previousLine = currentLine;
                currentLine = nextLine;
                nextLine = lineNumber + 1 < inputLines.Length ?
                    nextLine = ParseLine(inputLines[lineNumber + 1]) :
                    null;
                lineNumber++;
            }

            totalPart1 += (GetPartNumbersInLine(previousLine, currentLine, new Line()));

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }

        static public int GetPartNumbersInLine(Line previousLine, Line currentLine, Line nextLine)
        {
            var partSum = 0;

            foreach (var number in currentLine.Numbers)
            {
                if (previousLine.Symbols.Any(x => x >= number.StartPosition - 1 && x <= number.EndPosition + 1) ||
                    currentLine.Symbols.Any(x => x >= number.StartPosition - 1 && x <= number.EndPosition + 1) ||
                    nextLine.Symbols.Any(x => x >= number.StartPosition - 1 && x <= number.EndPosition + 1))
                {
                    partSum += number.Value;
                }
            }

            return partSum;
        }

        static public Line ParseLine(string currentLine)
        {
            var line = new Line();
            Number currentNumber = null;

            for (int position = 0; position < currentLine.Length; position++)
            {
                if (currentLine[position].IsNumber())
                {
                    currentNumber ??= new Number(position);
                    currentNumber.sb.Append(currentLine[position]);
                }
                else
                {
                    if (currentNumber != null)
                    {
                        currentNumber.End(position - 1);
                        line.Numbers.Add(currentNumber);
                        currentNumber = null;
                    }

                    if (currentLine[position] != '.')
                    {
                        line.Symbols.Add(position);
                    }
                }
            }

            if (currentNumber != null)
            {
                currentNumber.End(currentLine.Length - 1);
                line.Numbers.Add(currentNumber);
            }

            return line;
        }
    }
}
