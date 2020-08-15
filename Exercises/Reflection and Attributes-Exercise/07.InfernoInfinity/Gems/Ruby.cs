namespace _07.InfernoInfinity
{
    public class Ruby : Gem
    {
        public Ruby(string clarity)
        {
            var value = GemPowerModificator.IncreaseGemPower(clarity);

            this.Strength = DefaultValues.DefaultRubyStrength + value;
            this.Agility = DefaultValues.DefaultRubyAgility + value;
            this.Vitality = DefaultValues.DefaultRubyVitality + value;

        }
    }
}
