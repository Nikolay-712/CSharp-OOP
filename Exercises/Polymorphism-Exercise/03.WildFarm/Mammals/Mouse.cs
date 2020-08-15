using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Mouse : Mammal
    {
        private static double MouseFoodModificator = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProducieSound()
        {
            return "Squeak";
        }

        public override void CheckFoodType(Food food)
        {
            var typeFood = food.GetType().Name;
            if (typeFood != "Vegetable" && typeFood != "Fruit")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }
            base.CheckFoodType(food);
            IncreaseAnimalWeight(food);
        }

        private void IncreaseAnimalWeight(Food food)
        {
            this.Weight = this.Weight + food.Quantity * MouseFoodModificator;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";

        }
    }
}
