using System.Collections.Generic;
using BlackJack.Game.Participants.Hands;

namespace BlackJack.Game.Participants
{
    public interface IDealer : IParticipant
    {
        DealerHand Hand { get; }
    }
}
