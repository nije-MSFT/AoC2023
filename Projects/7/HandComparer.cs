namespace AoC2023_7
{
    public class HandComparer : IComparer<Hand>
    {
        private Dictionary<char, int> CardValues = new Dictionary<char, int>()
        {
            {'A', 13 },
            {'K', 12 },
            {'Q', 11 },
            {'J', 10 },
            {'T', 9 },
            {'9', 8 },
            {'8', 7 },
            {'7', 6 },
            {'6', 5 },
            {'5', 4 },
            {'4', 3 },
            {'3', 2 },
            {'2', 1 },
        };

        public HandComparer()
        {

        }
        public int Compare(Hand a, Hand b)
        {
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
    }
}
