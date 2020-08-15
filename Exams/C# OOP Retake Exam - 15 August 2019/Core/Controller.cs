namespace SpaceStation.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using SpaceStation.Core.Contracts;
    using SpaceStation.Core.Factories;
    using SpaceStation.Models.Mission;
    using SpaceStation.Repositories;
    using SpaceStation.Utilities.Messages;
    public class Controller : IController
    {
        private AstronautRepository astronautRepository;
        private AstrounautFactory astrounautFactory;

        private PlanetFactory planetFactory;
        private PlanetRepository planetRepository;


        private Mission mission;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.astrounautFactory = new AstrounautFactory();

            this.planetRepository = new PlanetRepository();
            this.planetFactory = new PlanetFactory();

            this.mission = new Mission();

        }


        public string AddAstronaut(string type, string astronautName)
        {
            var astrounaut = this.astrounautFactory.Create(type, astronautName);
            this.astronautRepository.Add(astrounaut);

            return string.Format(OutputMessages.AstronautAdded, astrounaut.GetType().Name, astrounaut.Name);

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = this.planetFactory.Create(planetName);

            if (items != null)
            {
                foreach (var item in items)
                {
                    planet.Items.Add(item);
                }
            }
            this.planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planet.Name);
        }

        public string ExplorePlanet(string planetName)
        {
            var astrounautsFomMision = this.astronautRepository.Models
                .Where(x => x.Oxygen > 60)
                .ToArray();

            var planet = this.planetRepository.FindByName(planetName);

            if (astrounautsFomMision.Length == 0)
            {
                throw new InvalidOperationException
                    ((ExceptionMessages.InvalidAstronautCount));
            }

            mission.Explore(planet, astrounautsFomMision);

            return string.Format(OutputMessages.PlanetExplored
                , planetName
                , astrounautsFomMision.Where(x => x.CanBreath == false).Count()
                );
        }

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            var astrounauts = string.Join(Environment.NewLine, this.astronautRepository.Models);

            builder
                .AppendLine($"{this.mission.exploredPlanets} planets were explored!")
                .AppendLine("Astronauts info:").AppendLine(astrounauts.ToString());

            return builder.ToString().TrimEnd();


        }

        public string RetireAstronaut(string astronautName)
        {
            var astrounaut = this.astronautRepository.FindByName(astronautName);

            if (astrounaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            return string.Format(OutputMessages.AstronautRetired, astrounaut.Name);
        }
    }
}
