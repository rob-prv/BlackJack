using System.Collections.Generic;

namespace BlackJack
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

        public Hand DrawCard(Deck deck)
        {
            var updatedHand = Hand.AddCard(deck.DrawCard());
            return updatedHand;
        }
    }
}
