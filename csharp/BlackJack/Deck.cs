using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        private readonly Random _rng = new Random();
        private List<Card> _cards = new List<Card>();

        public List<Card> Cards
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
                for (int i = 1; i < 14; i++)
                {
                    _cards.Add(new Card() { Rank = i, Suit = suit });
                }
            }

            Shuffle();
        }

        public Card DrawCard()
        {
            var card = _cards.FirstOrDefault();
            _cards.Remove(card);
            return card;
        }
    }
}
