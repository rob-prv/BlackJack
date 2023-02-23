using BlackJack.Game.Deck;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_Empty : Scenario
    {
        private IDeck _deck;
        private int _numberOfCards;

        public override void Given()
        {
            _deck = new Deck();
        }

        public override void When()
        {
            _deck.Cards.Clear();
            _numberOfCards = _deck.Cards.Count;
        }

        public override void TearDown()
        {
            _deck = null;
            _numberOfCards = 0;
        }

        [Test]
        public void Should_add_52_new_cards()
        {
            Assert.AreEqual(52, _numberOfCards);
        }
    }
}
