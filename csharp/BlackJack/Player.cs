namespace BlackJack
{
    public class Player : IPlayer
    {
        public PlayerHand Hand { get; }

        public Player(PlayerHand hand)
        {
            Hand = hand;
        }

        public Hand DrawCard(Deck deck)
        {
            var updatedHand = Hand.AddCard(deck.DrawCard());
            return updatedHand;
        }
        public void ResetHand()
        {
            Hand.ClearHand();
        }

        public Hand CloseHand()
        {
            var closedHand = Hand.CloseHand();
            return closedHand;
        }
    }
}
