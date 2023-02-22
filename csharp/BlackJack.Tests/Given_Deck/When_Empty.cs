using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_Empty : Scenario
    {
        private Deck _deck;
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

        [Test]
        public void Should_add_52_new_cards()
        {
            Assert.AreEqual(52, _numberOfCards);
        }
    }
}
