using System;
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
        public List<Card> cards;
        public Deck()
        {
            this.cards = new List<Card>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 1; j < 14; j++)
                {
                    Card card = new Card(j, i);
                    this.cards.Add(card);
                }
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            // go through half
            for(int i=0;i<(this.cards.Count/2);i++)
            {
                // swap this.cards[i] with this.cards[rand]
                int randy = rand.Next(this.cards.Count);
                Card card = this.cards[i];
                this.cards[i] = this.cards[randy];
                this.cards[randy] = card;
            }
        }
        public Card Deal()
        {
            Card cardToDeal = this.cards[0];
            this.cards.RemoveAt(0);
            return cardToDeal;
        }
    }
    class Player
    {
        List<Card> Hand = new List<Card>();
        public Player()
        {

        }
        public void Draw(Card card)
        {
            Hand.Add(card);
        }
    }
}