using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Cat : Feline
    {
        private static double CatFoodModificator = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProducieSound()
        {
            return "Meow";
        }

        public override void CheckFoodType(Food food)
        {
            var typeFood = food.GetType().Name;
            if (typeFood != "Vegetable" && typeFood != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }
            base.CheckFoodType(food);
            IncreaseAnimalWeight(food);
        }

        private void IncreaseAnimalWeight(Food food)
        {
            this.Weight = this.Weight + food.Quantity * CatFoodModificator;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
