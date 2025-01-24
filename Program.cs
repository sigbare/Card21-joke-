using System;
using System.IO;

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


            var command = StartGame();
            if (command == "info");
            info();



            Console.ReadLine();
        }

        public static void info()
        {
            string filePath = Environment.CurrentDirectory + @"\ruls.txt";
            if(!File.Exists(filePath))
            {
                Console.WriteLine("file info error");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch
            {
                Console.WriteLine("error Read file info");
            }
            

        }

        public static void NewGame()
        {

        }

        public static string? StartGame() 
        { 
           Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Hello it's CardsGame like BlackJack but with new rulse");
            Console.WriteLine("if you wanna read rulse please write info ");
            Console.WriteLine("if you wanna start game write start");

            Console.WriteLine("________________________________");

            string? str = Console.ReadLine();
            bool g = false;
            while (!g)
            {
                if (str != null && (str == "info" || str == "start"))
                {
                    return str;
                    g = true;
                }
                str = Console.ReadLine();
            }
           
                
            Console.WriteLine("pls check command");

            return null;
        
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
