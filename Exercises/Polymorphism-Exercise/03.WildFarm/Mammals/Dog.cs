using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Dog : Mammal
    {
        private static double DocFoodModificator = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProducieSound()
        {
            return "Woof!";
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
            this.Weight = this.Weight + food.Quantity * DocFoodModificator;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";

        }
    }
}
