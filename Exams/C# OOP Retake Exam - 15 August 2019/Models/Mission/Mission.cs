namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;

    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Planets;

    public class Mission : IMission
    {
        public int exploredPlanets { get; private set; }

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            exploredPlanets++;

            var astrounaut = astronauts.FirstOrDefault(x => x.CanBreath == true);
            var items = planet.Items.ToList();

            while (true)
            {
                if (items.Count == 0)
                {
                    return;
                }

                var item = items.FirstOrDefault();
                items.Remove(item);

                astrounaut.Bag.Items.Add(item);
                astrounaut.Breath();

                if (items.Count == 0)
                {
                    return;
                }

                if (!astrounaut.CanBreath)
                {
                    astrounaut = astronauts.FirstOrDefault(x => x.CanBreath == true);

                    if (astrounaut == null)
                    {
                        return;
                    }
                }
            }


        }
    }
}
