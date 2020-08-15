namespace MortalEngines.Core.Factories
{
    using MortalEngines.Core.Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;

    public class PilotFactory : IFactory
    {
        public object Create(params object[] parameters)
        {
            string name = parameters[0].ToString();

            IPilot pilot = new Pilot(name);

            return pilot;
        }
    }
}
