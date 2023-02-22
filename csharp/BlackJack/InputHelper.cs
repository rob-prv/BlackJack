using System;

namespace BlackJack
{
    public static class InputHelper
    {
        public static PlayerAction GetPlayerAction(string message)
        {
            Console.WriteLine(message);
            var answer = Console.ReadLine();
            if (answer == "Hit")
                return PlayerAction.Hit;
            else if (answer == "Stand")
                return PlayerAction.Stand;
            else
                return PlayerAction.Unknown;
        }
    }
}
