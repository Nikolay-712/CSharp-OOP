namespace ViceCity.Models.Neghbourhoods
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players.Contracts;
    using ViceCity.Models.Guns.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public int deadCivilPlayers { get; private set; }

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            MainPlayerAttack(mainPlayer, civilPlayers);
            PlayerAttack(mainPlayer, civilPlayers);

        }

        private void MainPlayerAttack(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            IGun gun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);
            IPlayer player = civilPlayers.FirstOrDefault(x => x.IsAlive == true);

            while (true)
            {
                if (player == null || gun == null)
                {
                    break;
                }

                player.TakeLifePoints(gun.Fire());

                if (!gun.CanFire)
                {
                    player.GunRepository.Remove(gun);

                    gun = mainPlayer.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);

                }

                if (!player.IsAlive)
                {
                    civilPlayers.Remove(player);
                    this.deadCivilPlayers++;

                    player = civilPlayers.FirstOrDefault(x => x.IsAlive == true);

                }

                if (player == null || gun == null)
                {
                    break;
                }


            }


        }

        private void PlayerAttack(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            var players = civilPlayers.Where(x => x.IsAlive == true).Where(x => x.GunRepository.Models.Count > 0);

            foreach (IPlayer player in players)
            {
                IGun gun = player.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);

                while (true)
                {
                    mainPlayer.TakeLifePoints(gun.Fire());

                    if (!gun.CanFire)
                    {
                        player.GunRepository.Remove(gun);

                        gun = player.GunRepository.Models.FirstOrDefault(x => x.CanFire == true);
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        return;
                    }

                    if (gun == null)
                    {
                        break;
                    }

                }

                
            }

        }
    }
}
