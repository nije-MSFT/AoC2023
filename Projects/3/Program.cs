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
                totalPart2 += currentLine.Symbols
                    .Where(x => x.Value == '*')
                    .Sum(x => FindGearRatio(previousLine, currentLine, nextLine, x));

                previousLine = currentLine;
                currentLine = nextLine;
                nextLine = lineNumber + 1 < inputLines.Length ?
                    nextLine = ParseLine(inputLines[lineNumber + 1]) :
                    null;
                lineNumber++;
            }

            totalPart1 += GetPartNumbersInLine(previousLine, currentLine, new Line());
            totalPart2 += currentLine.Symbols
                .Where(x => x.Value == '*')
                .Sum(x => FindGearRatio(previousLine, currentLine, new Line(), x));

            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");
        }

        static public int GetPartNumbersInLine(Line previousLine, Line currentLine, Line nextLine)
        {
            var partSum = 0;

            foreach (var number in currentLine.Numbers)
            {
                if (previousLine.Symbols
                    .Concat(currentLine.Symbols
                        .Concat(nextLine.Symbols))
                    .Any(x => x.Position >= number.StartPosition - 1 && x.Position <= number.EndPosition + 1))
                {
                    partSum += number.Value;
                }
            }

            return partSum;
        }

        static public int FindGearRatio(Line previousLine, Line currentLine, Line nextLine, Symbol gear)
        {
            var potentialGearNeighbors =
                previousLine.Numbers
                .Concat(currentLine.Numbers
                    .Concat(nextLine.Numbers))
                .Where(x => gear.Position >= x.StartPosition - 1 && gear.Position <= x.EndPosition + 1)
                .ToArray();

            if (potentialGearNeighbors.Length == 2)
            {
                return potentialGearNeighbors[0].Value * potentialGearNeighbors[1].Value;
            }

            return 0;
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
                        line.Symbols.Add(new Symbol(position, currentLine[position]));
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
