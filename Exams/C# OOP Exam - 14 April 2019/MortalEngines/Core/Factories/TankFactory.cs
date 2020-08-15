namespace MortalEngines.Core.Factories
{
    using System;

    using MortalEngines.Core.Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
   
    public class TankFactory : IFactory
    {
        public object Create(params object[] parameters)
        {
            string name = parameters[0].ToString();
            double attack = Convert.ToDouble(parameters[1]);
            double defense = Convert.ToDouble(parameters[2]);

            ITank tank = new Tank(name, attack, defense);

            return tank;
        }
    }
}
