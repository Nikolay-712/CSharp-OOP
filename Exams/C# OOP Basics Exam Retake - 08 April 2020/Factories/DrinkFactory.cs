using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink Create(string type, string name, int servingSize, string brand)
        {
            IDrink drink = null;

            switch (type)
            {
                case "Alcohol":
                    drink = new Alcohol(name,servingSize,brand);
                    break;
                case "FuzzyDrink":
                    drink = new FuzzyDrink(name, servingSize, brand);
                    break;
                case "Juice":
                    drink = new Juice(name, servingSize, brand);
                    break;
                case "Water":
                    drink = new Water(name, servingSize, brand);
                    break;
            }

            return drink;
        }

    }
}
