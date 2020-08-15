using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int bonusHealthPoints = 40;
        private const int bonusDamigePointsForCard = 30;

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            this.CheckConditionOfPlayers(attackPlayer, enemyPlayer);

            this.CheckForBeginnerPLayer(attackPlayer, enemyPlayer);

            this.IncreasePlayersHealthPointsBeforeFight(attackPlayer, enemyPlayer);

            this.StartFight(attackPlayer, enemyPlayer);

        }

        private void CheckConditionOfPlayers(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");

            }
        }
        private void CheckForBeginnerPLayer(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            var attackPlayerType = attackPlayer.GetType().Name;
            var enemyPlayerType = enemyPlayer.GetType().Name;

            if (attackPlayerType == "Beginner")
            {
                IncreaseBeginnerPlayerPower(attackPlayer);
               
            }

            if (enemyPlayerType == "Beginner")
            {
                IncreaseBeginnerPlayerPower(enemyPlayer);
            }

           
        }


        private void IncreaseBeginnerPlayerPower(IPlayer player)
        {
            player.Health = player.Health + bonusHealthPoints;

            var cards = player.CardRepository.Cards;

            foreach (var card in cards)
            {
                card.DamagePoints = card.DamagePoints + bonusDamigePointsForCard;
            }
        }

        private void IncreasePlayersHealthPointsBeforeFight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            var attackPlayerCardsPoints = attackPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();
            var enemyPlayerCardsPoints = enemyPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();

            attackPlayer.Health = attackPlayer.Health + attackPlayerCardsPoints;
            enemyPlayer.Health = enemyPlayer.Health + enemyPlayerCardsPoints;
        }

        private void StartFight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            var attackPlayerDamigePoints = attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();
            var enemyPlayerDamigePoints = enemyPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum();

            while (true)
            {
                enemyPlayer.TakeDamage(attackPlayerDamigePoints);

                if (enemyPlayer.IsDead)
                {
                    return;
                }

                attackPlayer.TakeDamage(enemyPlayerDamigePoints);

                if (attackPlayer.IsDead)
                {
                    return;
                }
            }
        }

    }
}
