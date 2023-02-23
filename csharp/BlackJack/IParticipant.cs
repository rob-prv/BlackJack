using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public interface IParticipant
    {
        public Hand DrawCard(Deck deck);
        public void ResetHand();
    }
}
