namespace AoC2023_2
{
    internal class GameResult
    {
        public int GameId;
        public List<Dictionary<string, int>> Grabs;

        public GameResult(string line)
        {
            var gameIdAndResults = line.Split(':');
            
            GameId = int.Parse(gameIdAndResults[0].Split(' ')[1]);

            Grabs = new List<Dictionary<string,int>>();
            var grabs = gameIdAndResults[1].Split(';');

            foreach (var grab in gameIdAndResults[1].Split(';'))
            {
                Grabs.Add(grab.Split(',').ToDictionary(
                    colorAndCount => colorAndCount.Trim().Split(" ")[1],
                    colorAndCount => int.Parse(colorAndCount.Trim().Split(" ")[0])));
            }
        }

        public bool IsPossible(int minRed, int minBlue, int minGreen)
        {
            foreach (var grab in Grabs)
            {
                if (grab.GetValueOrDefault("green") > minGreen ||
                    grab.GetValueOrDefault("blue") > minBlue ||
                    grab.GetValueOrDefault("red") > minRed)
                {
                    return false;
                }
            }

            return true;
        }

        public int Power()
        {
            return 
                Grabs.Max(x => x.GetValueOrDefault("blue")) * 
                Grabs.Max(x => x.GetValueOrDefault("green")) * 
                Grabs.Max(x => x.GetValueOrDefault("red"));
        }
    }
}
