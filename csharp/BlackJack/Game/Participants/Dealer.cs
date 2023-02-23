using System.Collections.Generic;
using BlackJack.Game.Deck;
using BlackJack.Game.Participants.Hands;

namespace BlackJack.Game.Participants
{
    public class Dealer : IDealer
    {
        public DealerHand Hand { get; }

        public Dealer(DealerHand hand)
        {
            Hand = hand;
        }

        public void ResetHand()
        {
            Hand.ClearHand();
        }

        public Hand DrawCard(IDeck deck)
        {
            var updatedHand = Hand.AddCard(deck.DrawCard());
            return updatedHand;
        }
    }
}
