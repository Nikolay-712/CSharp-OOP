namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;
    using System;
    public class ArmorRepairKit : Item
    {
        private const int weight = 10;

        public ArmorRepairKit() 
            : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            throw new NotImplementedException();
        }
    }
}
