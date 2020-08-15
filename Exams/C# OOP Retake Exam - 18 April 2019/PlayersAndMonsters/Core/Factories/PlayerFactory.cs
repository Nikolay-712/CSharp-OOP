namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            if (type == "Advanced")
            {
                return new Advanced(new CardRepository(),username);
            }

            if (type == "Beginner")
            {
                return new Beginner(new CardRepository(), username);
            }


            return null;
        }
    }
}
