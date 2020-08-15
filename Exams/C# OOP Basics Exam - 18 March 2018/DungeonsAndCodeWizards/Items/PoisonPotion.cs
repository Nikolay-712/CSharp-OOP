namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;
    using System;
    public class PoisonPotion : Item
    {
        private const int weight = 5;

        public PoisonPotion() 
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
