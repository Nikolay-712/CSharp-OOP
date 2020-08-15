using System;
using System.Collections.Generic;
using System.Text;

namespace MuOnline.Models.Items.Sets.ElfSets.BuffSet
{
    public class BuffHelmet : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 20;
        private const int staminaPoints = 12;
        private const int energyPoints = 0;

        public BuffHelmet() 
            : base(strengthPoints, agilityPoints, staminaPoints, energyPoints)
        {
        }
    }
}
