namespace ViceCity.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models
        {
            get => this.guns.AsReadOnly();
        }

        public void Add(IGun gun)
        {
            var gunsByName = this.guns.Select(x => x.Name);

            if (!gunsByName.Contains(gun.Name))
            {
                this.guns.Add(gun);
            }
        }

        public IGun Find(string name)
        {
            var currentGun = this.guns.FirstOrDefault(x => x.Name == name);
            return currentGun;
        }

        public bool Remove(IGun gun)
        {
            var IsRemoved = this.guns.Remove(gun);
            return IsRemoved;
        }
    }
}
