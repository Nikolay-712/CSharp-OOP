namespace _07.InfernoInfinity
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class WeaponFactory
    {
        public static Weapon CreateWeapon(string[] info)
        {
            var weaponInfo = info[1].Split(" ");

            string levelRarity = weaponInfo[0];
            string weaponType = weaponInfo[1];
            string weaponName = info[2];

            Type weapon = typeof(Weapon);
            var dd = weapon.Assembly.GetTypes().FirstOrDefault(x => x.Name == weaponType);

            var currentWeapon = Activator.CreateInstance(dd, new object[] { levelRarity, weaponName });

            return (Weapon)currentWeapon;
        }

    }
}
