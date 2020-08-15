namespace SpaceStation.Core.Factories
{
    using SpaceStation.Models.Planets;
    public class PlanetFactory
    {
        public IPlanet Create(string name)
        {
            IPlanet planet = new Planet(name);

            return planet;

        }
    }
}
