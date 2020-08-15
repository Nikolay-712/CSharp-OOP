namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffBoots : Item
    {
        private const int strengthPoints = 16;
        private const int agilityPoints = 27;
        private const int staminaPoints = 10;
        private const int energyPoints = 0;

        public BuffBoots() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
