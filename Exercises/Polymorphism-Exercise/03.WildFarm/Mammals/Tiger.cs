using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Tiger : Feline
    {
        private static double TigerFoodModificator = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProducieSound()
        {
            return "ROAR!!!";
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
            this.Weight = this.Weight + food.Quantity * TigerFoodModificator;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
