using BlackJack.Game.Deck;
using BlackJack.Game.Participants.Hands;

namespace BlackJack.Game.Participants
{
    public interface IParticipant
    {
        public Hand DrawCard(IDeck deck);
        public void ResetHand();
    }
}
