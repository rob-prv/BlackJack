using System.Collections.Generic;

namespace BlackJack
{
    public class Dealer : IDealer
    {
        public Deck Deck { get; }
        public DealerHand DealerHand { get; }
        public IPlayer Player { get; }

        public Dealer(Deck deck, DealerHand hand, Player player)
        {
            Player = player;
            Deck = deck;
            DealerHand = hand;
        }

        public void ResetHands()
        {
            Player.Hand.ClearHand();
            DealerHand.ClearHand();
        }

        public Hand DrawPlayerCard()
        {
            var updatedHand = Player.Hand.AddCard(Deck.DrawCard());
            return updatedHand;
        }

        public Hand DrawDealerCard()
        {
            var updatedHand = DealerHand.AddCard(Deck.DrawCard());
            return updatedHand;
        }
        public List<Hand> DealCards()
        {
            var updatedDealerHand = DealerHand.AddCard(Deck.DrawCard());
            var updatedPlayerHand = Player.Hand.AddCard(Deck.DrawCard());
            return new List<Hand> { updatedDealerHand, updatedPlayerHand };
        }
    }
}
