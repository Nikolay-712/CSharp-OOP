using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        static Pizza pizza;
        static void Main(string[] args)
        {
            string pizzaInfo = Console.ReadLine();
            string pizzaName = string.Empty;
            try
            {
                while (pizzaInfo.ToLower() != "end")
                {
                    var info = pizzaInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    switch (info[0].ToLower())
                    {
                        case "pizza":

                            if (info.Length > 1)
                            {
                                 pizzaName = info[1];
                            }

                            pizza = new Pizza(pizzaName);
                            break;
                        case "dough":
                            string typeFlour = info[1];
                            string bakingTech = info[2];
                            double doughWeight = double.Parse(info[3]);

                            Dough dough = new Dough(typeFlour, bakingTech, doughWeight);
                            pizza.AddDough(dough);
                            break;
                        case "topping":
                            string typeTopping = info[1];
                            double weightTopping = double.Parse(info[2]);

                            Topping topping = new Topping(typeTopping, weightTopping);
                            pizza.AddTopping(topping);
                            break;
                        default:
                            break;
                    }


                    pizzaInfo = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.PizzaName} - {pizza.TotalCalories():F2} Calories.");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }



            
        }
    }
}
