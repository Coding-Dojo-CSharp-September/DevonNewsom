namespace doc_demo
{
    public class TarokkaCard : ICard
    {
        static string[] taroSuits = {"Swords", "Stars", "Coins", "Glyphs", "None"};
        private int _suit;
        private int _val;
        public TarokkaCard(int val, int suit)
        {
            _suit = suit;
            _val = val;
        }

        public string Suit
        {
            get{return taroSuits[_suit];}
        }
        public string Value
        {
            get
            {
                if(_val < 10)
                {
                    return $"{TaroValue} of {taroSuits[_suit]}";
                }
                return TaroValue;
            }
        }
        public string TaroValue
        {
            get
            {
                if(_val < 11 || _val > 52)
                {
                    switch(_val)
                    {
                        case 53:
                            return "Artifact";
                        case 52:
                            return "Horseman";
                        case 10:
                            return "Master";
                        default:
                            return _val.ToString();
                    }
                }
                else if(Suit == "Swords")
                {
                    switch(_val)
                    {
                        case 13:
                            return "Darklord";
                        case 12:
                            return "Mists";
                        default:
                            return "Executioner";
                    }
                }
                else if(Suit == "Glyphs")
                {
                    switch(_val)
                    {
                        case 13:
                            return "Ghost";
                        case 12:
                            return "Innocent";
                        default:
                            return "Marionette";
                    }
                }
                else if(Suit == "Coins")
                {
                    switch(_val)
                    {
                        case 13:
                            return "Broken One";
                        case 12:
                            return "Tempter";
                        default:
                            return "Beast";
                    }
                }
                else
                {
                    switch(_val)
                    {
                        case 13:
                            return "Donjon";
                        case 12:
                            return "Raven";
                        default:
                            return "Seer";
                    }
                }
            }
        }
    }
}