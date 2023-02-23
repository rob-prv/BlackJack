using BlackJack.Game.Deck;
using BlackJack.Game.Participants.Hands;

namespace BlackJack.Game.Participants
{
    public class Player : IPlayer
    {
        public PlayerHand Hand { get; }

        public Player(PlayerHand hand)
        {
            Hand = hand;
        }

        public Hand DrawCard(IDeck deck)
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
