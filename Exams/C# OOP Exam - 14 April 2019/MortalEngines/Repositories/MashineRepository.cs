namespace MortalEngines.Repositories
{
    using System.Linq;

    using MortalEngines.Entities.Contracts;
    using MortalEngines.Repositories.Contracts;
    using System.Collections.Generic;
    
    public class MashineRepository : IRepository
    {
        private IList<IMachine> machinesRepository;

        public MashineRepository()
        {
            this.machinesRepository = new List<IMachine>();
        }


        public void AddUnit(object unit)
        {
            this.machinesRepository.Add((IMachine)unit);
        }

        public bool Contains(string name)
        {
            var mashine = this.machinesRepository.FirstOrDefault(x => x.Name == name);

            if (mashine == null)
            {
                return false;
            }

            return true;
        }

        public object GetByName(string name)
        {
            if (Contains(name))
            {
                return this.machinesRepository.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
    }
}
