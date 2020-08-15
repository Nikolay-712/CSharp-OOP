namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using _03BarracksFactory.Models.Units;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            //TODO: implement for Problem 3
            var currentUnit = typeof(Unit).Assembly.GetTypes().FirstOrDefault(x => x.Name == unitType);

            return (Unit)Activator.CreateInstance(currentUnit);


        }
    }
}
