using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace testSomething
{
   


    internal class Program
    {
        private static Random rng = new Random();
        private static int shoot = -1;
        private static int dilshoot = -1;
        static void Main(string[] args)
        {
         
            var command = StartGame();

            while (true)
            {
                if (command == "info")
                {
                    info();
                    command = Console.ReadLine();
                }
                    
                if (command == "start")
                {
                    NewGame();
                    break;
                }
                   
            }

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
            Console.WriteLine("choose the difficulty: easy/medium/hard ");
            string dif = string.Empty;
            while (true)
            {
                
               dif = Console.ReadLine() ?? dif;
                if (dif == "easy" || dif == "medium" || dif == "hard")
                    break;
            }
            
            Revolver revolver = new Revolver(dif);

            Console.WriteLine("Start game");

            List<Card> cardsDeck = CreatNewCardDeck();

            bool game = true;

            int value = 0;

            List<string> yourHand  = new List<string>();

            Enumerable.Range(1,2).ToList().ForEach(_ => TakeCard(ref yourHand, ref value, ref cardsDeck));
            while (game)
            {
                OutPut(yourHand, value);

                Console.WriteLine("Is that enough or do you want to take another card  ");
                Console.WriteLine("yes/no");

                var command = Console.ReadLine();
                if (command == "yes")
                    TakeCard(ref yourHand,ref value, ref cardsDeck);
                if (command == "no")
                {
                    game = false;
                    break;
                }
            }
            CheckHand(ref value);
           
        }

        public static string? StartGame() 
        { 
           Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Hello it's CardsGame like BlackJack but with new rulse");
            Console.WriteLine("if you wanna read rulse please write info like a command ");
            Console.WriteLine("if you wanna start game write start like a command");
            Console.WriteLine("________________________________");

            string? str = Console.ReadLine();
            bool g = false;
            while (!g)
            {
                if (str != null && (str == "info" || str == "start"))
                {
                    return str;
                    
                }
                Console.WriteLine("pls check command");
                str = Console.ReadLine();

            }
           
          
            return null;
        
        }

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

        public static List<Card> CreatNewCardDeck()
        {
            CardDeck cardDeck = new CardDeck();

            cardDeck.CreateCardDeck();

            List<Card> cards = new List<Card>(cardDeck.GetCardDeck());

            Shuffle<Card>(cards);

            return cards;
        }

        public static void TakeCard(ref List<string> cards , ref int value , ref List<Card> cardsDeck)
        {
           cards.Add(cardsDeck[0].Name + " " + cardsDeck[0].CardType);
           value = value + cardsDeck[0].value;
           cardsDeck.Remove(cardsDeck[0]);
        }

        public static void OutPut(List<string> cards, int value)
        {
            foreach (string card in cards)
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("____________________________");
            Console.WriteLine("your score: " + value);


        }
        


        public static int DilerHand()
        {
            Random rnd = new Random();
           int value = rnd.Next(14, 21);
            return value;
        }


        public static void CheckHand(ref int value)
        {
            int dilHand = DilerHand();


            if (value > dilHand && value < 22)
            {
                Console.WriteLine($"diller score: {dilHand}");
                Console.WriteLine("you win");
                dilshoot++;
            }
            if (value == dilHand && value < 22)
            {
                Console.WriteLine($"diller score: {dilHand}");
                Console.WriteLine("draw");

                
            }
            if(value < dilHand && value < 22)
            {
                Console.WriteLine($"diller score: {dilHand}");
                Console.WriteLine("you lose");
                shoot++;
            }

            
        }


    }


    public class Revolver
    {
        Dictionary<string, int> Dif = new Dictionary<string, int>
    {
        {"easy",1 },
        {"medium",2 },
        {"hard",4 }

    };

        
        public int countBull { get; set; }

        public Revolver(string complexity) 
        {
           
           this.countBull = Dif[complexity];
        }


         public int[] ReloadRevolver()
        {
            Random rng = new Random();

            int[] drum = new int[5];

            int count = countBull;
            for(int i = 0; i < drum.Length; ++i)
            {
                if(count > 0) { drum[i] = 1; }
                
                drum[i] = 0;
                count--;
            }
            int n = drum.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = drum[k];
                drum[k] = drum[n];
                drum[n] = value;
            }

            return drum;

        }

    }
}
