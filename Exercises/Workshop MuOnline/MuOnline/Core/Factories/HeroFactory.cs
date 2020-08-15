namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using MuOnline.Core.Factories.Contracts;
    using MuOnline.Models.Heroes.HeroContracts;

    public class HeroFactory : IHeroFactory
    {
        public IHero Create(string heroType, string username)
        {
            var targetName = heroType.ToLower();

            var typeHero = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == targetName);

            if (typeHero == null)
            {
                throw new ArgumentNullException("Invalid Hero type!");
            }
            var hero = (IHero)Activator.CreateInstance(typeHero, new object[] { username });

            return hero;
        }
    }
}
