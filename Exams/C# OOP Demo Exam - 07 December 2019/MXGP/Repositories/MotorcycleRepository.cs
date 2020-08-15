namespace MXGP.Repositories
{
    using System.Linq;
    using System;

    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using MXGP.Utilities.Messages;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            var motorcyclesByName = this.motorcycles.Select(x => x.Model).ToArray();

            if (motorcyclesByName.Contains(model.Model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists,model.Model));
            }
            this.motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.motorcycles.AsReadOnly();
        }

        public IMotorcycle GetByName(string name)
        {
            var currentMotorcycle = this.motorcycles.FirstOrDefault(x => x.Model == name);

            if (currentMotorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, name));
            }

            return currentMotorcycle;
        }

        public bool Remove(IMotorcycle model)
        {
            var isRemoved = this.motorcycles.Remove(model);

            return isRemoved;
        }
    }
}
