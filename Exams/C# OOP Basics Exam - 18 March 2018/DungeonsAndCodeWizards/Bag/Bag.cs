namespace DungeonsAndCodeWizards.Bag
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DungeonsAndCodeWizards.Bag.Contracts;
    using DungeonsAndCodeWizards.Items;

    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; }

        public int Load => this.Items.Select(x => x.Weight).Sum();

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Load == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);

            if (item == null)
            {
                throw new ArgumentException("No item with name {name} in bag!");
            }

            return item;
        }
    }
}
