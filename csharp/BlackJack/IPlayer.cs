namespace BlackJack
{
    public interface IPlayer
    { 
        PlayerHand Hand { get; }
        Hand CloseHand();
    }
}
