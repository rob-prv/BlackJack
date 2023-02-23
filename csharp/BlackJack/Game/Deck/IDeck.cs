using BlackJack.Game.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Game.Deck
{
    public interface IDeck
    {
        List<ICard> Cards { get; }
        ICard DrawCard();
    }
}
