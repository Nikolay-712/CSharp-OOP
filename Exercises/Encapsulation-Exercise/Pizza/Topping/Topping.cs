using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private static double baseCalories = 2;

        private string typeTopping;
        private double weight;
        private double calories;

        public Topping(string typeTopping, double weight)
        {
            this.TypeTopping = typeTopping;
            this.Weight = weight;

            this.TotalCalories();
        }

        public double Calories
        {
            get { return this.calories; }
            private set { this.calories = value; }
        }

        private string TypeTopping
        {
            get { return this.typeTopping; }
            set
            {
                ToppingModifiers.ToppingMod(value);
                this.typeTopping = value;
            }
        }

        private double Weight
        {
            get { return this.weight; }
            set
            {
                ToppingModifiers.ValidToppingWeight(value, this.TypeTopping);
                this.weight = value;
            }
        }

        private double TotalCalories()
        {
            this.Calories = (this.Weight * baseCalories) * ToppingModifiers.ToppingMod(this.TypeTopping);

            return this.Calories;
        }
    }
}
