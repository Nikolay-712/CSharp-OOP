using System;
using System.Collections.Generic;
using System.Text;

namespace _03.WildFarm
{
    public abstract class Animal 
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public virtual void CheckFoodType(Food food)
        {
            this.FoodEaten = this.FoodEaten + food.Quantity;
        }
        

        public virtual string ProducieSound()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }


    }
}
