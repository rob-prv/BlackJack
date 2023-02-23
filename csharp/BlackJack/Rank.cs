using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BlackJack
{
    public class Rank
    {
        private int _value;
        public int Value => _value;

        public Rank(int value)
        {
            SetHandValue(value);
        }

        private void SetHandValue(int value)
        {
            _value = value switch
            {
                11 => 10,
                12 => 10,
                13 => 10,
                14 => 11,
                _ => value
            };
        }
    }
}
