using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.Tests.Given_Game
{
    public class When_Dealing : Scenario
    {
        private BlackJackGame _game;
        private int _numberOfCards;
        private List<Hand> _hands; 

        public override void Given()
        {
            _hands = new List<Hand>();
            _game = new BlackJackGame(new Dealer(new DealerHand()), new Player(new PlayerHand()), new Deck());
        }

        public override void When()
        {
            foreach (var hand in _game.StartDealing())
            {
                _numberOfCards += hand.Cards.Count;
                _hands.Add(hand);
            }
        }

        public override void TearDown()
        {
            _numberOfCards = 0;
            _game = null;
            _hands = null;
        }

        [Test]
        public void Should_deal_one_card_to_each_participant()
        {
            Assert.AreEqual(2, _numberOfCards);
        }

        [Test]
        public void Should_deal_first_card_to_dealer()
        {
            Assert.AreEqual(typeof(DealerHand), _hands.First().GetType());
        }
   
    }
}
