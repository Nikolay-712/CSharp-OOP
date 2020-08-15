using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood Create(string type, string name, decimal price)
        {
            IFood food = null;

            switch (type)
            {
                case "Dessert":
                    food = new Dessert(name, price);
                    break;
                case "MainCourse":
                    food = new MainCourse(name, price);
                    break;
                case "Salad":
                    food = new Salad(name, price);
                    break;
                case "Soup":
                    food = new Soup(name, price);
                    break;
                
            }

            return food;
        }
    }
}
