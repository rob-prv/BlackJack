using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public abstract class Hand
    {
        private Card _lastDrawnCard;
        protected Card LastDrawnCard => _lastDrawnCard;
        public List<Card> Cards { get; } = new List<Card>();
        public int Total => Cards.Sum(c => Math.Min(c.Rank.Value, 11));
        public bool BlackJack => Cards.Sum(c => Math.Min(c.Rank.Value, 11)) == 21;
        public bool IsFat => Cards.Sum(c => Math.Min(c.Rank.Value, 11)) > 21;
        public abstract bool ManualStand{ get; }
        public abstract bool IsClosed { get; }

        public Hand AddCard(Card card)
        {
            if (IsClosed)
                return this;

            Cards.Add(card);
            _lastDrawnCard = card;

            return this;
        }

        public virtual void ClearHand()
        {
            Cards.Clear();
            _lastDrawnCard = null;
        }
    }
}
