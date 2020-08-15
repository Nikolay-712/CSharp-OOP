namespace MuOnline.Models.Inventories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Items.Contracts;

    public class Inventory : IInventory
    {
        private readonly List<IItem> items;

        public Inventory()
        {
            this.items = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Items => this.items.AsReadOnly();

        public void AddItem(IItem item)
        {
            this.items.Add(item);
        }

        public bool RemoveItem(IItem item)
        {

            return true;
        }

        public IItem GetItem(string item)
        {
            var targetItem = this.items.FirstOrDefault(x => x.GetType().Name == item);
            if (targetItem == null)
            {
                throw new ArgumentNullException($"Hero does not have this Item: {item}");
            }

            return targetItem;
        }
    }
}
