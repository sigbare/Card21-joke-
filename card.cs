using System;
using System.Collections.Generic;

namespace testSomething
{
   
  

    public class CardDeck
    {
        Dictionary<int, string> cardsName = new Dictionary<int, string>
        {
            {0, "two" },
            {1, "three" },
            {2, "four" },
            {3, "five" },
            {4, "six" },
            {5, "seven" },
            {6, "eight" },
            {7, "nine" },
            {8, "ten" },
            {9, "jack" },
            {10, "queen" },
            {11, "king" },
            {12, "ace" }
           
        };
        Dictionary<int, string> cardsType = new Dictionary<int, string>
        {
            {0,"heart" },
            {1,"dimond" },
            {2,"club" },
            {3,"spade" }
        };
        Dictionary<int, int> cardsValue = new Dictionary<int, int>
        {
            {0,2},
            {1,3},
            {2,4},
            {3,5},
            {4,6},
            {5,7},
            {6,8},
            {7,9},
            {8,10},
            {9,10},
            {10,10},
            {11,10},
            {12,1},
        };


        const int NumberCards = 36; 
        List<Card> cards = new List<Card>();
        
        public void CreateCardDeck()
        {
            cards.Clear();
            
            for(int i = 0; i < 4; i++)
            {

                for(int  j = 0; j < 13; j++)
                {
          
                  cards.Add(new Card(cardsValue[j], cardsType[i], cardsName[j]));
            
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
        



        public Card(int value, string CardType, string Name ) 
        {
            this.value = value;
            this.CardType = CardType;
            this.Name = Name;
           
        }


    }


}
