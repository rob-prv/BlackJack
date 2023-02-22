namespace BlackJack
{
    public class Card
    {
        public Suit Suit;
        public int Rank;

        public override string ToString()
        {
            switch (Rank)
            {
                case 11:
                    return "J of " + Suit;
                case 12:
                    return "Q of " + Suit;
                case 13:
                    return "K of " + Suit;
                case 14:
                    return "A of " + Suit;
                default:
                    return Rank.ToString() + " of " + Suit;
            }
        }
    }
}
