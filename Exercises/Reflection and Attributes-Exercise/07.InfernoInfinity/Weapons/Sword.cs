namespace _07.InfernoInfinity
{
    public class Sword : Weapon
    {
        public Sword(string weaponLevelRarity, string weaponName) 
            : base(weaponLevelRarity, weaponName)
        {
            int value = WeaponsDamageModificator.IncreaseWeaponDamage(weaponLevelRarity);

            this.MinimumDamage = DefaultValues.DefaultSwordMinimumDamage * value;
            this.MaximumDamage = DefaultValues.DefaultSwordMaximumDamage * value;
            this.SocketsCount = DefaultValues.DefaultSwordSocketsCount;

            this.GemsColection = new GemsColection(this.SocketsCount);
        }
    }
}
