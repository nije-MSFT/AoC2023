namespace AoC2023_5
{
    public class MapRange
    {
        public long SourceRangeStart { get; }

        public long DestinationRangeStart { get; }

        public long RangeLength { get; }

        public MapRange(long destinationRangeStart, long sourceRangeStart, long rangeLength)
        {
            SourceRangeStart = sourceRangeStart;
            DestinationRangeStart = destinationRangeStart;
            RangeLength = rangeLength;
        }
    }
}
