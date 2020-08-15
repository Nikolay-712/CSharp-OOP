using System;
using System.Collections.Generic;
using System.Text;

namespace _05.MordorsCruelPlan
{
    public class FoodFactory
    {
        private static int energy;
        public static int FoodModificator(string foodType)
        {
            switch (foodType.ToLower())
            {
                case "cram":
                    energy = 2;
                    break;
                case "lembas":
                    energy = 3;
                    break;
                case "apple":
                    energy = 1;
                    break;
                case "melon":
                    energy = 1;
                    break;
                case "honeyCake":
                    energy = 5;
                    break;
                case "mushrooms":
                    energy = -10;
                    break;
                default:
                    energy = -1;
                    break;
            }

            return energy;
        }


    }
}
