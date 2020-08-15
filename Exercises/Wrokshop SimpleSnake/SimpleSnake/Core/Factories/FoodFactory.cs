using System.Linq;

using SimpleSnake.GameObjects.Foods;
using System;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core.Factories
{
    public static class FoodFactory
    {

        private const int MinValueOfRandomPosition = 0;
        static FoodFactory()
        {
            random = new Random();
        }

        private static Random random { get; set; }

        public static Food GenerateRandomFood(int widthCoordinate, int heightCoordinate)
        {
            var typeFoods = typeof(StartUp).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Food))).ToArray();

            var foodsColectionLenght = typeFoods.Length;

            var typeFood = typeFoods[random.Next(MinValueOfRandomPosition, foodsColectionLenght)];

            var coordinateX = random.Next(1, widthCoordinate - 1);
            var coordinateY = random.Next(1, heightCoordinate - 1);

            Coordinate coordinate = new Coordinate(coordinateX, coordinateY);

            return (Food)Activator.CreateInstance(typeFood, coordinate);
        }

    }
}
