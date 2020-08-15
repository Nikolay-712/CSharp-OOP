using DungeonsAndCodeWizards.Bag;
using DungeonsAndCodeWizards.Characters.Contracts;
using DungeonsAndCodeWizards.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double defaultBaseHealth = 50;
        private const double defaultBaseArmor = 25;
        private const double defaultAbilityPoints = 40;
        private const double defaultRestHealMultiplier = 0.5;

        private static Backpack bag = new Backpack();
        public Cleric(string name, Faction faction)
            : base(name, defaultBaseHealth, defaultBaseArmor, defaultAbilityPoints, bag, faction)
        {
            base.RestHealMultiplier = defaultRestHealMultiplier;
            base.BaseHealth = defaultBaseHealth;
            base.BaseArmor = defaultBaseArmor;
        }

        public void Heal(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this.GetType().Name != character.GetType().Name)
                {
                    throw new InvalidOperationException("Cannot heal enemy character!");
                }

                character.Health = character.Health + this.AbilityPoints;
            }


        }
    }
}
