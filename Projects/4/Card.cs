namespace AoC2023_4
{
    internal class Card
    {
        public int CardNumber { get; }
        
        public Dictionary<int, bool> WinningNumbers { get; }
        
        public Card(int cardNumber, IEnumerable<int> winningNumbers)
        {
            CardNumber = cardNumber;
            WinningNumbers = winningNumbers.ToDictionary(x => x, x => true);
        }

        public int GetCardValue(IEnumerable<int> playingNumbers)
        {
            var numberOfWins = playingNumbers.Count(x => WinningNumbers.GetValueOrDefault(x));

            if (numberOfWins > 0) 
            {
                return 1 << numberOfWins - 1;
            }

            return 0;
        }
    }
}
