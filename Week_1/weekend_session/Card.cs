using System.Collections.Generic;
namespace doc_demo
{
    public class Card
    {
        private int _suit;
        private int _val;
        static string[] suits = {"Spades", "Clubs", "Diamonds", "Hearts"};
        public string Suit
        {
            get{ return suits[_suit];}
        }
        public string Value
        {
            get
            {
                switch(_val)
                {
                    case 1:
                        return "Ace";
                    case 11:
                        return "Jack";
                    case 12: 
                        return "Queen";
                    case 13:
                        return "King";
                    default:
                        return _val.ToString();
                }
            }
        }
        public Card(int val, int suit)
        {
            _suit = suit;
            _val = val;
        }
    }
    public class Deck
    {
        public List<Card> deck;
        public Deck()
        {
            deck = new List<Card>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 1; j < 14; j++)
                {
                    Card card = new Card(j, i);
                    deck.Add(card);
                }
            }
        }

    }
}