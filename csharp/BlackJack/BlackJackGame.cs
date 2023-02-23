using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class BlackJackGame
    {
        public GamePhase Phase { get; private set; }
        private readonly IDealer _dealer;
        private readonly IPlayer _player;
        private readonly Deck _deck;

        public BlackJackGame(IDealer dealer, IPlayer player, Deck deck)
        {
            _dealer = dealer;
            _player = player;
            _deck = deck;
            Phase = GamePhase.Dealing;
        }

        public void Restart()
        {
            Phase = GamePhase.Dealing;
            _dealer.ResetHand();
            _player.ResetHand();
        }

        public IEnumerable<Hand> StartDealing()
        {
            if (Phase != GamePhase.Dealing)
                yield break;

            foreach (var hand in new List<Hand> { _dealer.DrawCard(_deck), _player.DrawCard(_deck) })
                yield return hand;

            Phase = GamePhase.PlayersTurn;
        }

        public string GetWinner()
        {
            var possibleWinners = new List<Hand> { _dealer.Hand, _player.Hand }
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
                updatedHand = _player.CloseHand();
                UpdateGamePhase(updatedHand);
                return updatedHand;
            }

            if (Phase == GamePhase.PlayersTurn)
                updatedHand = _player.DrawCard(_deck);
            else
                updatedHand = _dealer.DrawCard(_deck);

            UpdateGamePhase(updatedHand);
            return updatedHand;
        }

        private void UpdateGamePhase(Hand hand)
        {
            if(!(hand is { IsClosed: true })) 
                return;

            if (hand.BlackJack)
                Phase = GamePhase.Finished;
            else
            {
                Phase = Phase switch
                {
                    GamePhase.Dealing => GamePhase.PlayersTurn,
                    GamePhase.PlayersTurn => GamePhase.DealersTurn,
                    GamePhase.DealersTurn => GamePhase.Finished,
                    _ => Phase
                };
            }
        }
    }
}
