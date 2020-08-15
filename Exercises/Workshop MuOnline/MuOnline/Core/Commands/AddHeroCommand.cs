namespace MuOnline.Core.Commands
{
    using MuOnline.Core.Commands.Contracts;
    using MuOnline.Core.Factories;
    using MuOnline.Utilities;

    public class AddHeroCommand : ICommand
    {
        public string Execute(string[] inputArgs)
        {
            string heroType = inputArgs[2];
            string heroName = inputArgs[3];

            HeroFactory heroFactory = new HeroFactory();
            var hero = heroFactory.Create(heroType, heroName);

            LoadUtilities.LoadHeroRepository().Add(hero);

            return $"Successful create new Hero {heroType} - {heroName}";

        }
    }
}
