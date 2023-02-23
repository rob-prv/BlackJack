using System;
using System.Linq;

namespace BlackJack.Game.Participants.Hands
{
    public class PlayerHand : Hand
    {
        private bool _stand;
        public override bool IsClosed => _stand || IsFat || BlackJack;
        public override bool ManualStand => _stand;
        public Hand CloseHand()
        {
            _stand = true;
            return this;
        }

        public override void ClearHand()
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
