using System.Text;

namespace AoC2023_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");
            List<TimeDistancePair> pairs = new List<TimeDistancePair>();

            var times = inputLines[0].Split(':')[1].Split(' ').Where(x => x != string.Empty).ToList();
            var distances = inputLines[1].Split(':')[1].Split(' ').Where(x => x != string.Empty).ToList();

            var combinedTime = new StringBuilder();
            var combinedDistance = new StringBuilder();

            for (int x = 0; x < times.Count; x++)
            {
                var pair = new TimeDistancePair()
                {
                    Time = int.Parse(times[x]),
                    Distance = int.Parse(distances[x])
                };

                combinedTime.Append(times[x]);
                combinedDistance.Append(distances[x]);

                pairs.Add(pair);
            }

            var giantPair = new TimeDistancePair()
            {
                Time = long.Parse(combinedTime.ToString()),
                Distance = long.Parse(combinedDistance.ToString())
            };

            long combinations = 1;

            foreach (var pair in pairs)
            {
                combinations *= pair.NumberOfWaysToWin();
            }

            Console.WriteLine($"Part 1: {combinations}");
            Console.WriteLine($"Part 2: {giantPair.NumberOfWaysToWin()}");
        }
    }
}
