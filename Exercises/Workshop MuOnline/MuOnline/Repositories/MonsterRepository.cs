namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MuOnline.Models.Monsters.Contracts;
    using MuOnline.Repositories.Contracts;
    
    public class MonsterRepository : IRepository<IMonster>
    {
        private List<IMonster> monstersRepository;

        public MonsterRepository()
        {
            this.monstersRepository = new List<IMonster>();
        }

        public IReadOnlyCollection<IMonster> Repository 
            => this.monstersRepository.AsReadOnly();

        public void Add(IMonster monster)
        {
            this.monstersRepository.Add(monster);
        }

        public IMonster Get(string monstrName)
        {
            var targetMonstar = this.monstersRepository.FirstOrDefault(x => x.GetType().Name == monstrName);
            if (targetMonstar == null)
            {
                throw new ArgumentNullException($"Not found Monster with name: {monstrName}");
            }
           
            return targetMonstar;
        }

        public bool Remove(IMonster monster)
        {
            var isRemoved = this.monstersRepository.Remove(monster);
            return isRemoved;
           
        }
    }
}
