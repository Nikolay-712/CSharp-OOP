using DungeonsAndCodeWizards.Bag;
using DungeonsAndCodeWizards.Characters.Contracts;
using DungeonsAndCodeWizards.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public class Warrior : Character, IAttackable
    {
        private const double defaulthBaseHealth = 100;
        private const double defaultBaseArmor = 50;
        private const double defaultAbilityPoints = 40;

        private static Satchel bag = new Satchel();


        public Warrior(string name, Faction faction)
            : base(name, defaulthBaseHealth, defaultBaseArmor, defaultAbilityPoints, bag, faction)
        {
            base.BaseHealth = defaulthBaseHealth;
            base.BaseArmor = defaultBaseArmor;
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character)
                {
                    throw new InvalidOperationException("Cannot attack self!");
                }

                if (this.Faction == character.Faction)
                {
                    throw new InvalidOperationException($"Friendly fire! Both characters are from {character.Faction} faction!");
                }

                this.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
