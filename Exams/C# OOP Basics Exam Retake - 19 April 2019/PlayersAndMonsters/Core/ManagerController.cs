namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerFactory playerFactory;
        private CardFactory CardFactory;

        private PlayerRepository playerRepository;
        private CardRepository cardRepository;

        private BattleField battleField = new BattleField();

        public ManagerController()
        {
            this.playerFactory = new PlayerFactory();
            this.CardFactory = new CardFactory();

            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);
            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

        }

        public string AddCard(string type, string name)
        {
            var card = CardFactory.CreateCard(type, name);
            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);




        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = this.playerRepository.Find(attackUser);
            var enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                builder.AppendLine(string.Format(ConstantMessages.PlayerReportInfo
                , player.Username, player.Health, player.CardRepository.Cards.Count));

                foreach (var card in player.CardRepository.Cards)
                {
                    builder.AppendLine(string.Format
                        (ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                }

                builder.AppendLine(ConstantMessages.DefaultReportSeparator);
            }

           

            return builder.ToString().TrimEnd();
        }
    }
}
