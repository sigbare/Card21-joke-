namespace testSomething
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CardDeck cardDeck = new CardDeck();

            cardDeck.CreateCardDeck();

            List<Card> cards = new List<Card>(cardDeck.GetCardDeck());

            Shuffle<Card>(cards);

            foreach (Card card in cards)
            {
                Console.WriteLine(card.Name + " " + card.CardType);
            }
        }



        private static Random rng = new Random();
        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

        }
    }
}
