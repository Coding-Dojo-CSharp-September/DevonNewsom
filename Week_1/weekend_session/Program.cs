using System;

namespace doc_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            myDeck.Shuffle();

            Player sup = new Player();
            sup.Draw(myDeck.Deal());
            sup.Draw(myDeck.Deal());
            sup.Draw(myDeck.Deal());
            sup.Draw(myDeck.Deal());
            sup.Draw(myDeck.Deal());

        }
    }
}
