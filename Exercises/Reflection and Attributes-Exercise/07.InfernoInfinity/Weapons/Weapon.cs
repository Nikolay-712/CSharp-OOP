namespace _07.InfernoInfinity
{
    using System.Collections.Generic;

    public abstract class Weapon : IWeapon
    {

        public Weapon(string weaponLevelRarity, string weaponName)
        {
            
            this.Name = weaponName;
        }

        public string Name { get; protected set; }

        public int MinimumDamage { get;  set; }

        public int MaximumDamage { get;  set; }

        public int SocketsCount { get; protected set; }

        public GemsColection GemsColection { get; protected set; }
    }
}
