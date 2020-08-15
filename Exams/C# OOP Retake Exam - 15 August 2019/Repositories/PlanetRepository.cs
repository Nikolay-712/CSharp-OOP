namespace SpaceStation.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
   
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planets.AsReadOnly();

        public void Add(IPlanet planet)
        {
            this.planets.Add(planet);
        }

        public IPlanet FindByName(string name)
        {
            var planet = this.planets.FirstOrDefault(x => x.Name == name);
            return planet;

        }

        public bool Remove(IPlanet planet)
        {
            var isRemoved = this.planets.Remove(planet);
            return isRemoved;
        }
    }
}
