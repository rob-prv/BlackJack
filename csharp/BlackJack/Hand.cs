using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public abstract class Hand
    {
        protected Card LastDrawnCard { get; set; }
        public List<Card> Cards { get; } = new List<Card>();
        public int Total => Cards.Sum(c => Math.Min(c.Rank, 10));
        public virtual bool IsClosed { get; }
        public bool BlackJack => Cards.Sum(c => Math.Min(c.Rank, 10)) == 21;
        public bool IsFat => Cards.Sum(c => Math.Min(c.Rank, 10)) > 21;

        public Hand AddCard(Card card)
        {
            if (IsClosed)
                return this;

            DecideValueOfAce(card);
            Cards.Add(card);
            LastDrawnCard = card;

            return this;
        }

        public void ClearHand()
        {
            Cards.Clear();
            LastDrawnCard = null;
        }

        private void DecideValueOfAce(Card card)
        {
            if (card.Rank != 14)
                return;

            if (Total < 12)
                card.Rank = 10;
            else
                card.Rank = 1;
        }
    }
}
