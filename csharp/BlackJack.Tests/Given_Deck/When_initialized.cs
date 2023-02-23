using BlackJack.Game.Deck;
using NUnit.Framework;
using System.Linq;

namespace BlackJack.Tests.Given_Deck
{
    public class When_Initialized : Scenario
    {
        private IDeck _deck;
        private int _numberOfCards;
        private int _numberOfSuits;
        private IDeck _deckTwo;
        private bool _cardOrderIsEqual;

        public override void Given()
        {
            _deck = new Deck();
            _deckTwo = new Deck();
        }

        public override void When()
        {
            _numberOfCards = _deck.Cards.Count;
            _numberOfSuits = _deck.Cards.Select(x => (int)x.Suit).Distinct().ToList().Count;
            _cardOrderIsEqual = _deck.Cards.SequenceEqual(_deckTwo.Cards);
        }

        public override void TearDown()
        {
            _deck = null;
            _deckTwo = null;
            _numberOfCards = 0;
            _numberOfSuits = 0;
            _cardOrderIsEqual = false;
        }

        [Test]
        public void Should_have_52_cards()
        {
            Assert.AreEqual(52, _numberOfCards);
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            Assert.AreEqual(4, _numberOfSuits);
        }

        [Test]
        public void Should_be_shuffled()
        {
            Assert.AreEqual(false, _cardOrderIsEqual);
        }
    }
}
