using System;

namespace P02_CarsSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int engineCount = int.Parse(Console.ReadLine());

            CarSalesman.EngineCreator(engineCount);

            int carCount = int.Parse(Console.ReadLine());

            CarSalesman.CarCreator(carCount);

            foreach (var car in CarFactory.GetCar())
            {
                Console.WriteLine(car);
            }
        }
    }

}
