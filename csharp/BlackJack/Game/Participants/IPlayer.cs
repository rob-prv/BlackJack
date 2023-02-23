using BlackJack.Game.Participants.Hands;

namespace BlackJack.Game.Participants
{
    public interface IPlayer : IParticipant
    {
        PlayerHand Hand { get; }
        Hand CloseHand();
    }
}
