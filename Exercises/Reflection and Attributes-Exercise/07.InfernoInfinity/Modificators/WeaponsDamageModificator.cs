namespace _07.InfernoInfinity
{
    using System;
    using System.Reflection;
    using System.Linq;

    public static class WeaponsDamageModificator
    {
        public static int IncreaseWeaponDamage(string levelRarity)
        {
            Type enumType = typeof(LevelRarity);
            FieldInfo[] infos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            int value = 0;

            foreach (FieldInfo fieldInfo in infos)
            {
                var rarity = fieldInfo.Name;
                if (rarity == levelRarity)
                {
                    value = Convert.ToInt32(fieldInfo.GetValue(fieldInfo));
                    break;
                }
            }
            return value;

        }

        public static void IncreaseWeaponDamageWithGemPower(Weapon weapon)
        {
            var totalPowwr = weapon.GemsColection.ShowGemColection().Where(x => x != null);

            var strengthTotalPower = totalPowwr.Select(x => x.Strength).Sum();
            var agilityTotalPower = totalPowwr.Select(x => x.Agility).Sum();

            weapon.MinimumDamage = weapon.MinimumDamage + (strengthTotalPower * 2);
            weapon.MaximumDamage = weapon.MaximumDamage + (strengthTotalPower * 3);

            weapon.MinimumDamage = weapon.MinimumDamage + (agilityTotalPower * 1);
            weapon.MaximumDamage = weapon.MaximumDamage + (agilityTotalPower * 4);

        }
    }
}
