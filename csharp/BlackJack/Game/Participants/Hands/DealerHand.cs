using System;
using System.Linq;

namespace BlackJack.Game.Participants.Hands
{
    public class DealerHand : Hand
    {
        public override bool IsClosed => Cards.Sum(c => Math.Min(c.Rank.Value, 11)) >= 17 || IsFat || BlackJack;
        public override bool ManualStand => false;
        public override string ToString()
        {
            if (BlackJack)
                return "BLACKJACK! Dealer hit with " + LastDrawnCard + ". Total: " + Total;

            return "Dealer hit with " + LastDrawnCard + ". Total: " + Total;
        }
    }
}
