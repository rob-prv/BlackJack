using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public enum GamePhase { Dealing, PlayersTurn, DealersTurn, Finished }
    public class BlackJackGame
    {
        public GamePhase Phase { get; private set; }
        private readonly IDealer _dealer;
        public BlackJackGame(IDealer dealer)
        {
            _dealer = dealer;
            Phase = GamePhase.Dealing;
        }

        public void Restart()
        {
            Phase = GamePhase.Dealing;
            _dealer.ResetHands();
        }

        public IEnumerable<Hand> StartDealing()
        {
            if (Phase != GamePhase.Dealing)
                yield break;

            foreach (var hand in _dealer.DealCards())
                yield return hand;

            Phase = GamePhase.PlayersTurn;
        }

        public string GetWinner()
        {
            var possibleWinners = new List<Hand> { _dealer.DealerHand, _dealer.Player.Hand }
                .Where(h => !h.IsFat)
                .OrderBy(h => Math.Abs(h.Total - 21))
                .ToList();

            var totals = possibleWinners.Select(h => h.Total).ToList();
            if (!totals.Any() || (totals.Count > 1 && totals.ElementAt(0).Equals(totals.ElementAt(1))))
                return "It's a tie!";
            else
                return possibleWinners.First().GetType() == typeof(PlayerHand) ? "You won!" : "Dealer won.";
        }



        public Hand HitOrStand(PlayerAction action)
        {
            Hand updatedHand;
            if (action == PlayerAction.Stand)
            {
                updatedHand = _dealer.Player.CloseHand();
                UpdateGamePhase(updatedHand);
                return null;
            }

            if (Phase == GamePhase.PlayersTurn)
                updatedHand = _dealer.DrawPlayerCard();
            else
                updatedHand = _dealer.DrawDealerCard();

            UpdateGamePhase(updatedHand);
            return updatedHand;
        }

        private void UpdateGamePhase(Hand hand)
        {
            if (hand is { IsClosed: false })
                return;

            if (hand.BlackJack)
            {
                Phase = GamePhase.Finished;
                return;
            }

            switch (Phase)
            {
                case GamePhase.Dealing:
                    Phase = GamePhase.PlayersTurn;
                    break;
                case GamePhase.PlayersTurn:
                    Phase = GamePhase.DealersTurn;
                    break;
                case GamePhase.DealersTurn:
                    Phase = GamePhase.Finished;
                    break;
            }
        }



    }
}
