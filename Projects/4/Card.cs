namespace AoC2023_4
{
    internal class Card
    {
        public int CardNumber { get; }
        
        public Dictionary<int, bool> WinningNumbers { get; }

        public IEnumerable<int> PlayerNumbers { get; }

        public Card(int cardNumber, IEnumerable<int> winningNumbers, IEnumerable<int> playerNumbers)
        {
            CardNumber = cardNumber;
            WinningNumbers = winningNumbers.ToDictionary(x => x, x => true);
            PlayerNumbers = playerNumbers;
        }

        public int GetCardValue()
        {
            var numberOfWins = GetPlayerWinningNumbers().Count();

            if (numberOfWins > 0) 
            {
                return 1 << numberOfWins - 1;
            }

            return 0;
        }

        public IEnumerable<int> GetPlayerWinningNumbers()
        {
            return PlayerNumbers.Where(x => WinningNumbers.GetValueOrDefault(x));
        }
    }
}
