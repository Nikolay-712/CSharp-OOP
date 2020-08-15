using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffArmor : Item
    {

        private const int strengthPoints = 18;
        private const int agilityPoints = 17;
        private const int staminaPoints = 10;
        private const int energyPoints = 0;

        public BuffArmor() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
