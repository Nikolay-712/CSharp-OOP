namespace SpaceStation.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Utilities.Messages;
   
    public class AstrounautFactory
    {
        public IAstronaut Create(string type, string name)
        {
            var astrounautType = Assembly.GetAssembly(typeof(Astronaut)).GetTypes().FirstOrDefault(x => x.Name == type);

            if (astrounautType == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            return (IAstronaut)Activator.CreateInstance(astrounautType, name);
        }
    }
}
