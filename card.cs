using System;
using System.Collections.Generic;

namespace testSomething
{
   
    enum CardValue
    {
        
    }



    public class CardDeck
    {
        Dictionary<int, string> cardsName = new Dictionary<int, string>
        {
            {0, "six" },
            {1, "seven" },
            {2, "eight" },
            {3, "nine" },
            {4, "ten" },
            {5, "jack" },
            {6, "queen" },
            {7, "king" },
            {8, "ace" }
           
        };
        Dictionary<int, string> cardsType = new Dictionary<int, string>
        {
            {0,"heart" },
            {1,"dimond" },
            {2,"club" },
            {3,"spade" }
        };

        const int NumberCards = 36; 
        List<Card> cards = new List<Card>();
        
        public void CreateCardDeck()
        {
            cards.Clear();
            
            for(int i = 0; i < 4; i++)
            {

                for(int  j = 0; j < 9; j++)
                {
                    cards.Add(new Card(j, cardsType[i], cardsName[j]));
                }
   
            }

        }

        public List<Card> GetCardDeck()
        {
            return cards; 
        }

    }


    public class Card
    {
        public int value { get; set; }
        public string CardType { get; set; } 
        public string Name { get; set; }



        public Card(int value, string CardType, string Name) 
        {
            this.value = value;
            this.CardType = CardType;
            this.Name = Name;
        }


    }


}
