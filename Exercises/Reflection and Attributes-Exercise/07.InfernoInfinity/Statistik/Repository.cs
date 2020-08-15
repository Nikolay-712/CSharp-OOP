namespace _07.InfernoInfinity
{
    using System.Collections.Generic;
    using System.Linq;


    public class Repository
    {
        private List<Weapon> weaponsColection;

        public Repository()
        {
            this.weaponsColection = new List<Weapon>();
        }

        public void AddWeaponInColection(Weapon weapon)
        {
            this.weaponsColection.Add(weapon);
        }

        public Weapon ShowCurrentWeapon(string weaponName)
        {
            var currentWeapon = weaponsColection.FirstOrDefault(x => x.Name == weaponName);

            return currentWeapon;
        }
    }
}
