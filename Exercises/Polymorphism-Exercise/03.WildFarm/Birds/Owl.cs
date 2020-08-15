using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Owl : Bird
    {
        private static double OwlFoodModificator = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProducieSound()
        {
            return "Hoot Hoot";
        }
        public override void CheckFoodType(Food food)
        {
            var typeFood = food.GetType().Name;
            if (typeFood != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }
            base.CheckFoodType(food);
            IncreaseAnimalWeight(food);
        }
        private void IncreaseAnimalWeight(Food food)
        {
            this.Weight = this.Weight + food.Quantity * OwlFoodModificator;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
