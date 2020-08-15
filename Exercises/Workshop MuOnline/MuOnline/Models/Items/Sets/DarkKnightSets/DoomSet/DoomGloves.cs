namespace MuOnline.Models.Items.Sets.DarkKnightSets.DoomSet
{
    public class DoomGloves : Item
    {
        private const int strengthPoints = 18;
        private const int agilityPoints = 17;
        private const int staminaPoints = 10;
        private const int energyPoints = 0;
       

        public DoomGloves() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
