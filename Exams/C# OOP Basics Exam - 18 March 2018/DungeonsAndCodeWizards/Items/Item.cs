namespace DungeonsAndCodeWizards.Items
{
    using DungeonsAndCodeWizards.Characters;
    using DungeonsAndCodeWizards.Items.Contracts;

    public abstract class Item : IItem
    {
        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public int Weight { get; }

        public abstract void AffectCharacter(Character character);
        
    }
}
