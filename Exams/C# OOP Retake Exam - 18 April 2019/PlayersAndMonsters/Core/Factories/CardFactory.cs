namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            if (type == "Magic")
            {
                return new MagicCard(name);
            }

            if (type == "Trap")
            {
                return new TrapCard(name);
            }

            return null;
        }
    }
}
