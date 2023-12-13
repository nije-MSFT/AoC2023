namespace AoC2023_7
{
    public class Hand
    {
        public HandType TypeOfHand { get; }
        
        public int Wager { get; }

        public string Cards { get; }

        public Hand(string line)
        {
            var cardsAndWager = line.Split(' ');
            Wager = int.Parse(cardsAndWager[1]);
            Cards = cardsAndWager[0];
            TypeOfHand = DetermineHandType(Cards);
        }

        private HandType DetermineHandType(string cards)
        {
            var cardCounts = cards.AsEnumerable()
                .GroupBy(x => x)
                .ToDictionary(y => y.Key, y => y.Count());

            if (cardCounts.Keys.Count == 1)
            {
                return HandType.FiveOfAKind;
            }
            if (cardCounts.Keys.Count == 2)
            {
                return cardCounts.Values.Max() == 4 ?
                    HandType.FourOfAKind :
                    HandType.FullHouse;
            }
            if (cardCounts.Keys.Count == 3)
            {
                return cardCounts.Values.Max() == 3 ?
                    HandType.ThreeOfAKind :
                    HandType.TwoPair;
            }
            if (cardCounts.Keys.Count == 4)
            {
                return HandType.OnePair;
            }

            return HandType.HighCard;
        }
    }
}
