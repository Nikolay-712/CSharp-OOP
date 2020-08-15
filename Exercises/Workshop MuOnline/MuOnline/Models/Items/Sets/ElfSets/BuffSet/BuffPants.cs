namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{

    public class BuffPants : Item
    {
        private const int strengthPoints = 20;
        private const int agilityPoints = 0;
        private const int staminaPoints = 2;
        private const int energyPoints = 10;

        public BuffPants() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
