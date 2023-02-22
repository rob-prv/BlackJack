using System;
using System.Threading;

namespace BlackJack
{
    class Program
    {
        static void Main()
        {
            var game = new BlackJackGame(new Dealer(new Deck(), new DealerHand(), new Player(new PlayerHand()))); 
            // more ideal with factory

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

                if (updatedHand?.BlackJack == true)
                    Console.WriteLine(updatedHand);

                else if (updatedHand?.BlackJack == false)
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
