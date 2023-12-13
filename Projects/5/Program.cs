namespace AoC2023_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");

            bool readingMap = false;
            List<string> mapLines = new List<string>();
            List<Map> listOfMaps = new List<Map>();
            List<long> seeds = new List<long>();
            List<SeedRange> seedRanges = new List<SeedRange>();

            foreach (var line in inputLines)
            {
                if (line.StartsWith("seeds:"))
                {
                    seeds = line.Split(':')[1].Trim().Split(' ').Select(x => long.Parse(x)).ToList();
                    for (int i = 0; i < seeds.Count; i+=2)
                    {
                        seedRanges.Add(new SeedRange(seeds[i], seeds[i+1]));
                    }
                }

                if (readingMap)
                {
                    if (line == string.Empty)
                    {
                        readingMap = false;
                        listOfMaps.Add(new Map(mapLines));
                        mapLines.Clear();
                    }
                    else
                    {
                        mapLines.Add(line);
                    }
                }
                else
                {
                    if (line.Contains("map:"))
                    {
                        readingMap = true;
                        mapLines.Add(line);
                    }
                }
            }

            if (readingMap)
            {
                listOfMaps.Add(new Map(mapLines));
                mapLines.Clear();
            }

            var maps = listOfMaps.ToDictionary(x => x.Name, x => x);

            Dictionary<long, long> seedToLocation = new Dictionary<long, long>();

            foreach (var seed in seeds)
            {
                var soil = maps["seed-to-soil"].GetTranslation(seed);
                var fertilizer = maps["soil-to-fertilizer"].GetTranslation(soil);
                var water = maps["fertilizer-to-water"].GetTranslation(fertilizer);
                var light = maps["water-to-light"].GetTranslation(water);
                var temperature = maps["light-to-temperature"].GetTranslation(light);
                var humidity = maps["temperature-to-humidity"].GetTranslation(temperature);
                var location = maps["humidity-to-location"].GetTranslation(humidity);

                seedToLocation[seed] = location;
            }

            Console.WriteLine($"Part 1: {seedToLocation.Values.Min()}");

            var lowestLocation = long.MaxValue;

            for (long location = 0; location < long.MaxValue; location++)
            {
                var humidity = maps["humidity-to-location"].GetReverseTranslation(location);
                var temperature = maps["temperature-to-humidity"].GetReverseTranslation(humidity);
                var light = maps["light-to-temperature"].GetReverseTranslation(temperature);
                var water = maps["water-to-light"].GetReverseTranslation(light);
                var fertilizer = maps["fertilizer-to-water"].GetReverseTranslation(water);
                var soil = maps["soil-to-fertilizer"].GetReverseTranslation(fertilizer);
                var seed = maps["seed-to-soil"].GetReverseTranslation(soil);

                foreach (var range in seedRanges)
                {
                    if (seed >= range.SeedStart && seed <= range.SeedStart + range.RangeLength)
                    {
                        lowestLocation = location;
                        break;
                    }
                }

                if (lowestLocation != long.MaxValue)
                {
                    break;
                }
            }

            Console.WriteLine($"Part 2: {lowestLocation}");
        }
    }
}
