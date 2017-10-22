using System;
using System.Collections.Generic;

namespace doc_demo
{
    public class Deck
    {
        public List<ICard> cards;

        public void Shuffle()
        {
            Random rand = new Random();
            // go through half
            for(int i=0;i<(this.cards.Count/2);i++)
            {
                // swap this.cards[i] with this.cards[rand]
                int randy = rand.Next(this.cards.Count);
                ICard card = this.cards[i];
                this.cards[i] = this.cards[randy];
                this.cards[randy] = card;
            }
        }
        public ICard Deal()
        {
            ICard cardToDeal = this.cards[0];
            this.cards.RemoveAt(0);
            return cardToDeal;
        }
    }
    public class TarokkaDeck
    {

    }
    public class ClassicDeck : Deck
    {
        public ClassicDeck()
        {
            this.cards = new List<ICard>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 1; j < 14; j++)
                {
                    ClassicCard card = new ClassicCard(j, i);
                    this.cards.Add(card);
                }
            }
        }
    }
    public class TaroHigh : Deck
    {
        public TaroHigh()
        {
            this.cards = new List<ICard>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 11; j < 14; j++)
                {
                    TarokkaCard card = new TarokkaCard(j, i);
                    this.cards.Add(card);
                }
            }
            TarokkaCard jk1 = new TarokkaCard(53, 4);
            TarokkaCard jk2 = new TarokkaCard(54, 4);
            this.cards.Add(jk1);
            this.cards.Add(jk2);
        }
    }
    public class TaroCommon : Deck
    {
        public TaroCommon()
        {
            this.cards = new List<ICard>();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 1; j < 11; j++)
                {
                    TarokkaCard card = new TarokkaCard(j, i);
                    this.cards.Add(card);
                }
            }

        }

    }
}
