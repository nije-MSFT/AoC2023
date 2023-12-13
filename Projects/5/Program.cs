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

            foreach (var line in inputLines)
            {
                if (line.StartsWith("seeds:"))
                {
                    seeds = line.Split(':')[1].Trim().Split(' ').Select(x => long.Parse(x)).ToList();
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
        }
    }
}
