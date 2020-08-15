namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");

            }

            //If the player is a beginner, increase his health with 40 points 
            // increase all damage points of all cards for the user with 30.

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health = attackPlayer.Health + 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints = card.DamagePoints + 30;
                }
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health = enemyPlayer.Health + 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints = card.DamagePoints + 30;
                }
            }


            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(x => x.HealthPoints);

            // attackPlayer attack First
            // enemyPlayer attackSecond

           
            while (true)
            {
                var attackPlayerTotalDamagePoints = attackPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                enemyPlayer.TakeDamage(attackPlayerTotalDamagePoints);

                if (enemyPlayer.Health == 0)
                {
                    break;
                }

                var enemyPlayerTotalDamagePoints = enemyPlayer.CardRepository.Cards.Sum(d => d.DamagePoints);
                attackPlayer.TakeDamage(enemyPlayerTotalDamagePoints);

                if (attackPlayer.Health == 0)
                {
                    break;
                }
            }


        }

        private void GetBonusHealthPoints(IPlayer player)
        {
            var cardsofplayer = player.CardRepository.Cards;

            var bonusHealthPoints = cardsofplayer.Select(x => x.HealthPoints).Sum();

            player.Health = player.Health + bonusHealthPoints;

            
        }
    }
}
