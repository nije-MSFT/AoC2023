using System.Runtime.CompilerServices;

namespace AoC2023_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputLines = File.ReadAllLines(".\\Input.txt");

            var totalPart1 = 0;
            var totalPart2 = 0;

            Dictionary<int, Card> cards = new Dictionary<int, Card>();

            foreach (var line in inputLines)
            {
                var cardNumberAndOtherNumbers = line.Split(':');

                var playerNumbersAndWinningNumbers = cardNumberAndOtherNumbers[1].Split('|');

                var card = new Card(
                    int.Parse(cardNumberAndOtherNumbers[0].Split(' ').Last()),
                    playerNumbersAndWinningNumbers[0].Split(' ').Where(x => x != string.Empty).Select(x => int.Parse(x)),
                    playerNumbersAndWinningNumbers[1].Split(' ').Where(x => x != string.Empty).Select(x => int.Parse(x)));

                cards[card.CardNumber] = card;
                totalPart1 += card.GetCardValue();
            }

            foreach (var card in cards.Values)
            {
                totalPart2 += GetCountOfCardsWon(card.CardNumber, cards);
            }

          
            Console.WriteLine($"Part 1: {totalPart1}");
            Console.WriteLine($"Part 2: {totalPart2}");

        }

        private static int GetCountOfCardsWon(int cardNumber, Dictionary<int, Card> cards)
        {
            var playerWins = cards[cardNumber].GetPlayerWinningNumbers().Count();
            var count = 1;

            for (int x = 1; x <= playerWins; x++)
            {
                count += GetCountOfCardsWon(cardNumber + x, cards);
            }

            return count;
        }
    }
}
