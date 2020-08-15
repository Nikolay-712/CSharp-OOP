using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Repositores
{
    public class ItemRepository
    {
        private List<Item> items;

        public ItemRepository()
        {
            this.items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            this.items.Add(item);
        }

        public Item GetLastItem()
        {
            var item = this.items.LastOrDefault();

            if (item == null)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            return item;
        }

        public void RemoveItem(Item item)
        {
            this.items.Remove(item);
        }
    }
}
