using System;

namespace doc_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            TaroCommon common = new TaroCommon();
            common.Shuffle();
            TaroHigh high = new TaroHigh();
            high.Shuffle();

            Player party = new Player();
            party.Draw(common.Deal());
            party.Draw(common.Deal());
            party.Draw(common.Deal());
            party.Draw(high.Deal());
            party.Draw(high.Deal());
            foreach(ICard card in party.Hand)
            {
                System.Console.WriteLine(card.Value);
            }

        }
    }
}
