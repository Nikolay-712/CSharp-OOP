using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Controller.Factories
{
    public class ItemFactory
    {
        private Item item;

        public Item Create(string name)
        {
            switch (name)
            {
                case "ArmorRepairKit":
                    this.item = new ArmorRepairKit();
                    break;
                case "HealthPotion":
                    this.item = new HealthPotion();
                    break;
                case "PoisonPotion":
                    this.item = new PoisonPotion();
                    break;
                default:
                    throw new ArgumentException($"Invalid item {name}!");
            }

            return this.item;
        }
    }
}
