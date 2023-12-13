namespace AoC2023_7
{
    public class Hand
    {        
        public int Wager { get; }

        public string Cards { get; }

        public HandType TypeOfHand { get; set; }

        public Hand(string line)
        {
            var cardsAndWager = line.Split(' ');
            Wager = int.Parse(cardsAndWager[1]);
            Cards = cardsAndWager[0];
        }
    }
}
