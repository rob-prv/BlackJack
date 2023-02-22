using System.Collections.Generic;

namespace BlackJack
{
    public interface IDealer
    {
        Deck Deck { get; }
        DealerHand DealerHand { get; }
        public List<Hand> DealCards();
        IPlayer Player { get; }
        Hand DrawPlayerCard();
        Hand DrawDealerCard();
        void ResetHands();
    }
}
