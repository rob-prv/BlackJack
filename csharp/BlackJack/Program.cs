using System;
using System.Threading;
using BlackJack.Game;
using BlackJack.Game.Deck;
using BlackJack.Game.Participants;
using BlackJack.Game.Participants.Hands;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            var game = new BlackJackGame(new Dealer( new DealerHand()), new Player(new PlayerHand()), new Deck());

            while (game.Phase != GamePhase.Finished)
            {
                if(game.Phase == GamePhase.DealersTurn)
                    Thread.Sleep(1000);

                foreach (var hand in game.StartDealing())
                    Console.WriteLine(hand);

                PlayerAction action;
                if (game.Phase == GamePhase.PlayersTurn)
                    action = InputHelper.GetPlayerAction("Stand, Hit");
                else
                    action = PlayerAction.Hit;

                var updatedHand = game.HitOrStand(action);
                if (!updatedHand.ManualStand)
                    Console.WriteLine(updatedHand);

                if (game.Phase == GamePhase.Finished)
                {
                    Thread.Sleep(700);
                    Console.WriteLine(game.GetWinner());

                    Console.WriteLine("Play again? Yes, No");
                    var answer = Console.ReadLine()?.ToUpper();
                    if (answer == "YES")
                        game.Restart();
                }
            }
        }
    }
}
