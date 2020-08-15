namespace MuOnline.Models.Items.Weapons.Swords
{
    public class HeavySword : Item
    {
        private const int strengthPoints = 25;
        private const int agilityPoints = 7;
        private const int staminaPoints = 0;
        private const int energyPoints = 12;

        public HeavySword()
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
