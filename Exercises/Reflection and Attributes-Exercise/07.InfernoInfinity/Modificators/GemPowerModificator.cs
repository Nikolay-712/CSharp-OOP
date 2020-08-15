namespace _07.InfernoInfinity
{
    using System;
    using System.Reflection;

    public static class GemPowerModificator
    {
        public static int IncreaseGemPower(string levelClarity)
        {
            Type enumType = typeof(LevelsClarity);
            FieldInfo[] infos = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            int value = 0;

            foreach (FieldInfo fieldInfo in infos)
            {
                var rarity = fieldInfo.Name;
                if (rarity == levelClarity)
                {
                    value = Convert.ToInt32(fieldInfo.GetValue(fieldInfo));
                    break;
                }
            }
            return value;
        }
    }
}
