namespace MuOnline.Models.Items.Weapons.Scipters
{
    public class MagickSkipter : Item
    {
        private const int strengthPoints = 15;
        private const int agilityPoints = 9;
        private const int staminaPoints = 6;
        private const int energyPoints = 8;


        public MagickSkipter()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
