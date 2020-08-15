using System;

namespace _05.MordorsCruelPlan
{
    public class Program
    {
        static void Main()
        {
            int foodCount = 0;

            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var food in input)
            {
                foodCount = foodCount + FoodFactory.FoodModificator(food);
            }

            Console.WriteLine(foodCount);

        }
    }
}
