using System;
using System.Linq;

namespace BlackJack
{
    public class PlayerHand : Hand
    {
        private bool _stand;
        public override bool IsClosed => _stand || Cards.Sum(c => Math.Min(c.Rank, 10)) >= 21;

        public Hand CloseHand()
        {
            _stand = true;
            return this;
        }

        public void ClearHand()
        {
            _stand = false;
            base.ClearHand();
        }

        public override string ToString()
        {
            if (BlackJack)
                return "BLACKJACK! You hit with " + LastDrawnCard + ". Total: " + Total;

            return "You hit with " + LastDrawnCard + ". Total: " + Total;
        }

    }
}
