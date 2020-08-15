namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomBoots : Item
    {

        private const int strengthPoints = 8;
        private const int agilityPoints = 17;
        private const int staminaPoints = 10;
        private const int energyPoints = 25;

        public DoomBoots() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
