namespace ViceCity.Core.Factoris
{
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    public class PlayerFactory : IFactory
    {
        public object Create(params object[] info)
        {
            string name = info[0].ToString();

            IPlayer player = new CivilPlayer(name);

            return player;
        }
    }
}
