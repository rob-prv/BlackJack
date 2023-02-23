using System.Collections.Generic;

namespace BlackJack
{
    public interface IDealer : IParticipant
    {
        DealerHand Hand { get; }
    }
}
