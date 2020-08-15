namespace AquaShop.Repositories
{
    
    using System.Collections.Generic;
    using System.Linq;

    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Repositories.Contracts;

    public class AquariumRepository : IRepository<IAquarium>
    {
        private List<IAquarium> models;

        public AquariumRepository()
        {
            this.models = new List<IAquarium>();
        }

        public IReadOnlyCollection<IAquarium> Models => this.models.AsReadOnly();

        public void Add(IAquarium model)
        {
            this.models.Add(model);
        }

        public IAquarium FindByType(string name)
        {
            var aquarium = this.models.FirstOrDefault(x => x.Name == name);
            return aquarium;
        }
        public bool Remove(IAquarium model)
        {
            var isRemoved = this.models.Remove(model);
            return isRemoved;
        }
    }
}
