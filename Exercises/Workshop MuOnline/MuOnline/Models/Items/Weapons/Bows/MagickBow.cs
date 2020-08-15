namespace MuOnline.Models.Items.Weapons.Bows
{
    public class MagickBow : Item
    {
        private const int strengthPoints = 20;
        private const int agilityPoints = 15;
        private const int staminaPoints = 2;
        private const int energyPoints = 14;

        public MagickBow()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
