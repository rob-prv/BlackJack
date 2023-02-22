namespace BlackJack
{
    public enum PlayerAction { Hit, Stand, Unknown }
    public class Player : IPlayer
    {
        public PlayerHand Hand { get; }

        public Player(PlayerHand hand)
        {
            Hand = hand;
        }

        public Hand CloseHand()
        {
            var closedHand = Hand.CloseHand();
            return closedHand;
        }
    }
}
