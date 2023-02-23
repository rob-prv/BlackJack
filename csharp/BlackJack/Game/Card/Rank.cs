namespace BlackJack.Game.Card
{
    public class Rank : IRank
    {
        private int _value;
        public int Value => _value;

        public Rank(int value)
        {
            SetHandValue(value);
        }

        private void SetHandValue(int value)
        {
            _value = value switch
            {
                11 => 10,
                12 => 10,
                13 => 10,
                14 => 11,
                _ => value
            };
        }
    }
}
