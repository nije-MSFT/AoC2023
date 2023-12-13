namespace AoC2023_7
{
    public class HandComparerForJokers : IComparer<Hand>
    {
        private Dictionary<char, int> CardValues = new Dictionary<char, int>()
        {
            {'A', 13 },
            {'K', 12 },
            {'Q', 11 },
            {'T', 10 },
            {'9', 9 },
            {'8', 8 },
            {'7', 7 },
            {'6', 6 },
            {'5', 5 },
            {'4', 4 },
            {'3', 3 },
            {'2', 2 },
            {'J', 1 },
        };

        public HandComparerForJokers()
        {

        }
        public int Compare(Hand a, Hand b)
        {
            a.TypeOfHand = DetermineHandType(a.Cards);
            b.TypeOfHand = DetermineHandType(b.Cards);

            if (a.TypeOfHand > b.TypeOfHand)
            {
                return 1;
            }
            if (a.TypeOfHand < b.TypeOfHand)
            {
                return -1;
            }

            for (int i = 0; i < a.Cards.Length; i++)
            {
                if (CardValues[a.Cards[i]] > CardValues[b.Cards[i]])
                {
                    return 1;
                }

                if (CardValues[a.Cards[i]] < CardValues[b.Cards[i]])
                {
                    return -1;
                }
            }

            return 0;
        }

        public static HandType DetermineHandType(string cards)
        {
            var cardCounts = cards.AsEnumerable()
                .GroupBy(x => x)
                .ToDictionary(y => y.Key, y => y.Count());

            if (!cardCounts.Keys.Contains('J'))
            {
                return HandComparer.DetermineHandType(cards);
            }

            if  (cardCounts.Keys.Count <= 2)
            {
                return HandType.FiveOfAKind;
            }

            if (cardCounts.Keys.Count == 3)
            {
                return cardCounts.Values.Max() + cardCounts['J'] >= 4 ?
                    HandType.FourOfAKind :
                    HandType.FullHouse;
            }

            if (cardCounts.Keys.Count == 4)
            {
                return HandType.ThreeOfAKind;
            }

            if (cardCounts.Keys.Count == 3)
            {
                return HandType.TwoPair;
            }

            if (cardCounts.Keys.Count == 5)
            {
                return HandType.OnePair;
            }

            return HandType.HighCard;
        }
    }
}
