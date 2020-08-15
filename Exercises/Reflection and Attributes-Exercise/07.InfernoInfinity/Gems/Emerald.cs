namespace _07.InfernoInfinity
{
    public class Emerald : Gem
    {
        public Emerald(string clarity)
        {
            var value = GemPowerModificator.IncreaseGemPower(clarity);

            this.Strength = DefaultValues.DefaultEmeraldStrength + value;
            this.Agility = DefaultValues.DefaultEmeraldAgility + value;
            this.Vitality = DefaultValues.DefaultEmeraldVitality + value;
        }
    }
}
