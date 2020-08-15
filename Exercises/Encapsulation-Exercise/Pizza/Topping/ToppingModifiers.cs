using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class ToppingModifiers
    {
        private static double toppingCal;

        public static double ToppingMod(string toppingType)
        {
            switch (toppingType.ToLower())
            {
                case "meat":
                    toppingCal = 1.2;
                    break;
                case "veggies":
                    toppingCal = 0.8;
                    break;
                case "cheese":
                    toppingCal = 1.1;
                    break;
                case "sauce":
                    toppingCal = 0.9;
                    break;
                default:
                    throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");

            }

            return toppingCal;
        }

        public static void ValidToppingWeight(double weight, string type)
        {
            if (weight < 1 || weight > 50)
            {
                throw new ArgumentException($"{type} weight should be in the range [1..50].");
            }
        }

    }
}
