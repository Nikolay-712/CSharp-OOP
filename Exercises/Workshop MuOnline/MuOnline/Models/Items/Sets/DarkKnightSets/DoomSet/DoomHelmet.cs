namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomHelmet : Item
    {
        private const int strengthPoints = 12;
        private const int agilityPoints = 10;
        private const int staminaPoints = 0;
        private const int energyPoints = 4;
       

        public DoomHelmet() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
