using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Game.Card;

namespace BlackJack.Game.Participants.Hands
{
    public abstract class Hand
    {
        private ICard _lastDrawnCard;
        protected ICard LastDrawnCard => _lastDrawnCard;
        public List<ICard> Cards { get; } = new List<ICard>();
        public int Total => Cards.Sum(c => Math.Min(c.Rank.Value, 11));
        public bool BlackJack => Cards.Sum(c => Math.Min(c.Rank.Value, 11)) == 21;
        public bool IsFat => Cards.Sum(c => Math.Min(c.Rank.Value, 11)) > 21;
        public abstract bool ManualStand { get; }
        public abstract bool IsClosed { get; }

        public Hand AddCard(ICard card)
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
