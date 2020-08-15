namespace MortalEngines.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using MortalEngines.Entities.Contracts;
    using MortalEngines.Repositories.Contracts;
   
    public class PilotRepository : IRepository
    {
        private IList<IPilot> pilotsRepository;

        public PilotRepository()
        {
            this.pilotsRepository = new List<IPilot>();
        }

        public void AddUnit(object unit)
        {
            this.pilotsRepository.Add((IPilot)unit);
        }

        public bool Contains(string name)
        {
            var pilot = this.pilotsRepository.FirstOrDefault(x => x.Name == name);

            if (pilot == null)
            {
                return false;
            }

            return true;


        }

        public object GetByName(string name)
        {
            if (Contains(name))
            {
                return this.pilotsRepository.FirstOrDefault(x => x.Name == name);
            }

            return null;
        }
    }
}
