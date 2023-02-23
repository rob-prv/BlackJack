namespace BlackJack
{
    public interface IPlayer : IParticipant
    {
        PlayerHand Hand { get; }
        Hand CloseHand();
    }
}
