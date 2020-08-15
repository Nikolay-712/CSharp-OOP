using System;

namespace P02_CarsSalesman
{
    public class CarSalesman
    {
        public static void EngineCreator(int engineCount)
        {
            for (int i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

                EngineFactory.CreateEngine(parameters);
            }
        }

        public static void CarCreator(int carCount)
        {
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

                CarFactory.CreateCar(parameters);
            }
        }

    }
}
