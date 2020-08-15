using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private const double defaultRestHealMultiplier = 0.2;

        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag.Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health;
            this.BaseHealth = health;
            this.Armor = armor;
            this.BaseArmor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.RestHealMultiplier = defaultRestHealMultiplier;
            this.IsAlive = true;

        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");

                }
                this.name = value;
            }
        }
        public double BaseHealth { get; protected set; }
        public double Health { get; internal set; }
        public double BaseArmor { get; protected set; }
        public double Armor { get; private set; }
        public double AbilityPoints { get; }
        public Bag.Bag Bag { get; }
        public Faction Faction { get; }
        public bool IsAlive { get; private set; }
        public double RestHealMultiplier { get; protected set; }

        public void TakeDamage(double hitPoints)
        {
            if (this.Armor - hitPoints >= 0)
            {
                this.Armor = this.Armor - hitPoints;
            }
            else
            {
                this.Armor = 0;


                if (this.Health - (hitPoints - this.Armor) < 0)
                {
                    this.IsAlive = false;
                }
                else
                {
                    this.Health = this.Health - (hitPoints - this.Armor);
                }
            }


        }

        public void Rest()
        {
            if (this.IsAlive)
            {
                this.Health = this.Health + (this.BaseHealth * this.RestHealMultiplier);
            }
        }

        public void UseItem(Item item)
        {

        }

        public void UseItemOn(Item item, Character character)
        {

        }

        public void GiveCharacterItem(Item item, Character character)
        {

        }

        public void ReceiveItem(Item item)
        {

        }





    }
}
