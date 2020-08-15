using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class DoughModifiers
    {
        private static double flourCalories;
        private static double bakingTechniqueCal;
        public static double FlourModifier(string flourType)
        {
            switch (flourType.ToLower())
            {
                case "white":
                    flourCalories = 1.5;
                    break;
                case "wholegrain":
                    flourCalories = 1.0;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
                    
            }

            return flourCalories;
        }

        public static double TechniqueModifier(string technique)
        {
            switch (technique.ToLower())
            {
                case "crispy":
                    bakingTechniqueCal = 0.9;
                    break;
                case "chewy":
                    bakingTechniqueCal = 1.1;
                    break;
                case "homemade":
                    bakingTechniqueCal = 1.0;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
                    
            }

            return bakingTechniqueCal;
        }

        public static void ValidWeightOfDough(double weight)
        {
            if (weight < 1 || weight > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
        }


    }
}
