using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Game.Card;

namespace BlackJack.Game.Deck
{
    public class Deck : IDeck
    {
        private readonly Random _rng = new Random();
        private List<ICard> _cards = new List<ICard>();

        public List<ICard> Cards
        {
            get
            {
                if (!_cards.Any())
                    InitializeDeck();

                return _cards;
            }
        }

        public Deck()
        {
            InitializeDeck();
        }

        private void Shuffle()
        {
            _cards = _cards.OrderBy(c => _rng.Next()).ToList();
        }

        private void InitializeDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 2; i < 15; i++)
                    _cards.Add(new Card.Card(new Rank(i), i, suit));
            }

            Shuffle();
        }

        public ICard DrawCard()
        {
            var card = _cards.FirstOrDefault();
            _cards.Remove(card);
            return card;
        }
    }
}
