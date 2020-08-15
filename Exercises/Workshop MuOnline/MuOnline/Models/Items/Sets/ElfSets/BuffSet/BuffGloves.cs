namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffGloves : Item
    {
        private const int strengthPoints = 16;
        private const int agilityPoints = 7;
        private const int staminaPoints = 0;
        private const int energyPoints = 5;

        public BuffGloves()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
