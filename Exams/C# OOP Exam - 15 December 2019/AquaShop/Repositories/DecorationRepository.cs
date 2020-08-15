namespace AquaShop.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using AquaShop.Utilities.Messages;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decorationModel = this.models.FirstOrDefault(x => x.GetType().Name == type);

            if (decorationModel == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, type));
            }

            return decorationModel;

        }

        public bool Remove(IDecoration model)
        {
            var isRemoved = this.models.Remove(model);
            return isRemoved;
        }
    }
}
