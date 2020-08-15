namespace _07.InfernoInfinity
{
    public class Axe : Weapon
    {
        public Axe(string weaponLevelRarity, string weaponName)
            : base(weaponLevelRarity, weaponName)
        {
            int value = WeaponsDamageModificator.IncreaseWeaponDamage(weaponLevelRarity);

            this.MinimumDamage = DefaultValues.DefaultAxeMinimumDamage * value;
            this.MaximumDamage = DefaultValues.DefaultAxeMaximumDamage * value;
            this.SocketsCount = DefaultValues.DefaultAxeSocketsCount;

            this.GemsColection = new GemsColection(this.SocketsCount);
        }
    }
}
