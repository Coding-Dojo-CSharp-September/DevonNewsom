using System;
using System.Collections.Generic;
namespace doc_demo
{
    public interface ICard
    {
        string Value {get;}
        string Suit {get;}
    }

    public class ClassicCard : ICard
    {
        private int _suit;
        private int _val;
        static string[] suits = {"Spades", "Clubs", "Diamonds", "Hearts", "None"};
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
        public ClassicCard(int val, int suit)
        {
            _suit = suit;
            _val = val;
        }
    }
    
    class Player
    {
        public List<ICard> Hand = new List<ICard>();
        public Player()
        {

        }
        public void Draw(ICard card)
        {
            Hand.Add(card);
        }
    }
}