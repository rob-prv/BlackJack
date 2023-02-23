using BlackJack.Game;
using BlackJack.Game.Deck;
using BlackJack.Game.Participants;
using BlackJack.Game.Participants.Hands;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Game
{
    public class When_Initialized : Scenario
    {
        private BlackJackGame _game;
        private int _numberOfCards;
        private GamePhase _gamePhase;

        public override void Given()
        {
            _game = new BlackJackGame(new Dealer(new DealerHand()), new Player(new PlayerHand()), new Deck());
        }

        public override void When()
        {
            _gamePhase = _game.Phase;
        }

        public override void TearDown()
        {
            _game = null;
            _numberOfCards = 0;
        }

        [Test]
        public void GamePhase_Should_be_dealing()
        {
            Assert.AreEqual(GamePhase.Dealing, _gamePhase);
        }
    }
}
