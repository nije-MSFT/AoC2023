using System.Security.Cryptography;

namespace AoC2023_5
{
    public class Map
    {
        public string Name { get; }

        public List<MapRange> ranges { get; } = new List<MapRange>();

        public Map(IEnumerable<string> mapInputLines)
        {
            foreach (var mapInputLine in mapInputLines)
            {
                if (mapInputLine == string.Empty)
                {
                    continue;
                }

                if (mapInputLine.EndsWith("map:"))
                {
                    Name = mapInputLine.Split(' ')[0];
                }
                else
                {
                    var rangeMapData = mapInputLine.Split(' ');
                    ranges.Add(new MapRange(long.Parse(rangeMapData[0]), long.Parse(rangeMapData[1]), long.Parse(rangeMapData[2])));
                }
            }
        }

        public long GetTranslation(long input)
        {
            foreach (var range in ranges)
            {
                if (input >= range.SourceRangeStart && input < range.SourceRangeStart + range.RangeLength)
                {
                    return range.DestinationRangeStart + (input - range.SourceRangeStart);
                }
            }

            //No mapping found
            return input;
        }
    }
}
