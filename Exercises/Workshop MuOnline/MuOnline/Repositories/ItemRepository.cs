namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using MuOnline.Models.Items.Contracts;

    public class ItemRepository : IRepository<IItem>
    {
        private readonly List<IItem> itemRepository;

        public ItemRepository()
        {
            this.itemRepository = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Repository
            => this.itemRepository.AsReadOnly();

        public void Add(IItem item)
        {
            this.itemRepository.Add(item);
        }

        public IItem Get(string itemNamae)
        {
            var targetItem = this.itemRepository.FirstOrDefault(x => x.GetType().Name == itemNamae);
            if (targetItem == null)
            {
                throw new ArgumentNullException($"Not found Item with name: {itemNamae}");
            }

            return targetItem;
        }
        public bool Remove(IItem item)
        {
            return true;
        }

        
    }
}
