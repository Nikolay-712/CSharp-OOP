using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private static double baseCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;

            this.TotalCalories();
        }

        public double Calories
        {
            get { return this.calories; }
            private set { this.calories = value; }
        }

        private double Weight 
        {
            get { return this.weight; }
            set 
            {
                DoughModifiers.ValidWeightOfDough(value);
                this.weight = value;
            }
        }

        private string BakingTechnique 
        {
            get { return this.bakingTechnique; }
            set
            {
                DoughModifiers.TechniqueModifier(value);
                this.bakingTechnique = value;
            }
        }

        private string FlourType
        {
            get { return this.flourType; }
            set
            {
                DoughModifiers.FlourModifier(value);
                this.flourType = value;
            }
        }

        private double TotalCalories()
        {
            this.Calories =
                (this.Weight * baseCalories)
                * DoughModifiers.FlourModifier(this.FlourType)
                * DoughModifiers.TechniqueModifier(this.BakingTechnique);


            return this.Calories;
        }

    }
}
