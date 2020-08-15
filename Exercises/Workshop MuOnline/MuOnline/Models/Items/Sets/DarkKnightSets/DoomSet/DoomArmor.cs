namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomArmor : Item
    {
        private const int strengthPoints = 16;
        private const int agilityPoints = 7;
        private const int staminaPoints = 0;
        private const int energyPoints = 5;

        public DoomArmor() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
