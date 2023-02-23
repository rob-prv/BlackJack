namespace BlackJack.Game.Card
{
    public class Card : ICard
    {
        public Suit Suit { get; }
        public int Value { get; }
        public IRank Rank { get; }

        public Card(IRank rank, int value, Suit suit)
        {
            Rank = rank;
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            return Value switch
            {
                11 => "J of " + Suit,
                12 => "Q of " + Suit,
                13 => "K of " + Suit,
                14 => "A of " + Suit,
                _ => Rank.Value + " of " + Suit
            };
        }
    }
}
