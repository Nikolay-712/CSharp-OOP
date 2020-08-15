namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double oxygen = 70;

        public Biologist(string name) 
            : base(name, oxygen)
        {
        }

        public override void Breath()
        {
            var neededOxygen = this.Oxygen - 5;

            if (neededOxygen < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen = this.Oxygen - 5;
            }
        }
    }
}
