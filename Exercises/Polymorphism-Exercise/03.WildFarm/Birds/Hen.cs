using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public class Hen : Bird
    {
        private static double HenFoodModificator = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProducieSound()
        {
            return "Cluck";
        }
        public override void CheckFoodType(Food food)
        {
            base.CheckFoodType(food);
            IncreaseAnimalWeight(food);
        }

        private void IncreaseAnimalWeight(Food food)
        {
            this.Weight = this.Weight + food.Quantity * HenFoodModificator;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
