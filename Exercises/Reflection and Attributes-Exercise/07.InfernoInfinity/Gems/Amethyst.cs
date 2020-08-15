namespace _07.InfernoInfinity
{
    public class Amethyst : Gem
    {
        public Amethyst(string clarity)
        {
            var value = GemPowerModificator.IncreaseGemPower(clarity);

            this.Strength = DefaultValues.DefaultAmethystStrength + value;
            this.Agility = DefaultValues.DefaultAmethystAgility + value;
            this.Vitality = DefaultValues.DefaultEAmethystVitality + value;
        }
    }
}
