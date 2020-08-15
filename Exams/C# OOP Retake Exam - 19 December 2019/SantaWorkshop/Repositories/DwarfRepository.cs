namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> models;

        public DwarfRepository()
        {
            this.models = new List<IDwarf>();
        }

        public IReadOnlyCollection<IDwarf> Models => this.models;

        public void Add(IDwarf dwart)
        {

            this.models.Add(dwart);
        }

        public IDwarf FindByName(string name)
        {
            var currentDwarf = this.models.FirstOrDefault(x => x.Name == name);
            return currentDwarf;
        }

        public bool Remove(IDwarf dwarf)
        {
            var isRemoved = this.models.Remove(dwarf);
            return isRemoved;
        }
    }
}
