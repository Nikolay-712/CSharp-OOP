namespace ViceCity.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using ViceCity.Core.Contracts;
    using ViceCity.Core.Factoris;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Repositories;
    public class Controller : IController
    {
        private List<IPlayer> players;

        private GunFactory gunFactory;
        private PlayerFactory playerFactory;
        private MainPlayer mainPlayer;

        private GunRepository gunRepository;
        private GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.gunFactory = new GunFactory();
            this.playerFactory = new PlayerFactory();
            this.mainPlayer = new MainPlayer();

            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
            this.players = new List<IPlayer>();
        }


        public string AddGun(string type, string name)
        {
            IGun gun = (IGun)this.gunFactory.Create(type, name);
            this.gunRepository.Add(gun);

            return $"Successfully added {gun.Name} of type: {gun.GetType().Name}";
        }

        public string AddGunToPlayer(string name)
        {
            var currentGun = this.gunRepository.Models.FirstOrDefault();

            if (currentGun == null)
            {
                return "There are no guns in the queue!";
            }

            var player = this.players.FirstOrDefault(x => x.Name == name);

            if (player == null && name != "Vercetti")
            {
                return "Civil player with that name doesn't exists!";

            }

            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(currentGun);
                this.gunRepository.Remove(currentGun);

                return $"Successfully added {currentGun.Name} to the Main Player: Tommy Vercetti";

            }


            player.GunRepository.Add(currentGun);
            this.gunRepository.Remove(currentGun);

            return $"Successfully added {currentGun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer player = (IPlayer)this.playerFactory.Create(name);
            this.players.Add(player);

            return $"Successfully added civil player: {player.Name}!";
        }

        public string Fight()
        {
            this.gangNeighbourhood.Action(this.mainPlayer, players);

            if (this.mainPlayer.LifePoints == 100 && this.gangNeighbourhood.deadCivilPlayers == 0)
            {
                return "Everything is okay!";

            }

            StringBuilder builder = new StringBuilder();

            builder
                .AppendLine("A fight happened:")
                .AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!")
                .AppendLine($"Tommy has killed: {this.gangNeighbourhood.deadCivilPlayers} players!")
                .AppendLine($"Left Civil Players: {this.players.Count}!");

            return builder.ToString().TrimEnd();
        }
    }
}
