namespace _07.InfernoInfinity
{
    public class Knife : Weapon
    {
        public Knife(string weaponLevelRarity, string weaponName)
            : base(weaponLevelRarity, weaponName)
        {

            int value = WeaponsDamageModificator.IncreaseWeaponDamage(weaponLevelRarity);

            this.MinimumDamage = DefaultValues.DefaultKnifeMinimumDamage * value;
            this.MaximumDamage = DefaultValues.DefaultKnifeMaximumDamage * value;
            this.SocketsCount = DefaultValues.DefaultKnifeSocketsCount;

            this.GemsColection = new GemsColection(this.SocketsCount);
        }
    }
}
