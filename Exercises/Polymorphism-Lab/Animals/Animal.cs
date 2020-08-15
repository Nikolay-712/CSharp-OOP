using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favoriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favoriteFood;
        }

        public string FavouriteFood
        {
            get { return this.favouriteFood; }
            private set { this.favouriteFood = value; }
        }


        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
