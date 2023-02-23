using System;
using System.Linq;

namespace BlackJack
{
    public class DealerHand : Hand
    {
        public override bool IsClosed => Cards.Sum(c => Math.Min(c.Rank.HandValue, 11)) >= 17 || IsFat;
        public override bool ManualStand => false; 
        public override string ToString()
        {
            if (BlackJack)
                return "BLACKJACK! Dealer hit with " + LastDrawnCard + ". Total: " + Total;

            return "Dealer hit with " + LastDrawnCard + ". Total: " + Total;
        }
    }
}
