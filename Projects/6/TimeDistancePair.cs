namespace AoC2023_6
{
    public class TimeDistancePair
    {
        public long Time;
        public long Distance;

        public TimeDistancePair()
        {
        }

        public long NumberOfWaysToWin()
        {
            long numberOfWins = 0;
            for (long i = 1; i < Time; i++)
            {
                if ((Time - i) * i > Distance)
                {
                    numberOfWins++;
                }
            }

            return numberOfWins;
        }
    }
}
