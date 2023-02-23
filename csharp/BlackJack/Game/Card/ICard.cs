using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Game.Card
{
    public interface ICard
    { 
        Suit Suit { get; }
        int Value { get; }
        IRank Rank { get; }
    }
}
