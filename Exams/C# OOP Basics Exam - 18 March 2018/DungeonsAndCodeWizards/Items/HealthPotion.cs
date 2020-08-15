namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;
    using System;
    public class HealthPotion : Item
    {
        private const int weight = 5;
        public HealthPotion() 
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
