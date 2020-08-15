namespace SantaWorkshop.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Repositories.Contracts;
    
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> models;

        public PresentRepository()
        {
            this.models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this.models;

        public void Add(IPresent present)
        {
            this.models.Add(present);
        }

        public IPresent FindByName(string name)
        {
            var currentPresent = this.models.FirstOrDefault(x => x.Name == name);
            return currentPresent;
        }

        public bool Remove(IPresent present)
        {
            var isRemoved = this.models.Remove(present);
            return isRemoved;
        }
    }
}
