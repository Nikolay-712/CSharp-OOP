namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MuOnline.Models.Heroes.HeroContracts;
    using MuOnline.Repositories.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroesRepository;

        public HeroRepository()
        {
            this.heroesRepository = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Repository
            => this.heroesRepository.AsReadOnly();

        public void Add(IHero hero)
        {
            this.heroesRepository.Add(hero);
        }

        public IHero Get(string heroName)
        {
            var targetHero = this.heroesRepository.FirstOrDefault(x => ((IIdentifiable)x).Username == heroName);
            if (targetHero == null)
            {
                throw new ArgumentNullException($"Not found Hero with name: {heroName}");
            }
            return targetHero;
        }

        public bool Remove(IHero hero)
        {
            var isRemoved = this.heroesRepository.Remove(hero);
            return isRemoved;

        }
    }
}
