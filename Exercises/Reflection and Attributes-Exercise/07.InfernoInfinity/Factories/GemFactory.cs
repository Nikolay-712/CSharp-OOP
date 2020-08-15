namespace _07.InfernoInfinity
{
    using System;
    using System.Linq;

    public static class GemFactory
    {
        public static Gem CreateGem(string[] info)
        {
            var gemInfo = info[3].Split(" ");

            string gemType = gemInfo[1];
            string levelClarity = gemInfo[0];

            Type gems = typeof(Gem);
            var dd = gems.Assembly.GetTypes().FirstOrDefault(x => x.Name == gemType);

            var currentGem = Activator.CreateInstance(dd, new object[] { levelClarity });

            return (Gem)currentGem;

        }
    }
}
