using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{

    public class Garage
    {
        private static List<Car> carGarage = new List<Car>();

        public static void AddCarInGarage(Car car)
        {
            carGarage.Add(car);
        }

        public static void ShowCurrentCar(string command)
        {
              if (command == "fragile")
              {
                List<string> fragile = carGarage
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.TiresPressure.Any(y => y < 1))
                      .Select(x => x.Model)
                      .ToList();
            
                  Console.WriteLine(string.Join(Environment.NewLine, fragile));
              }
              else
              {
                  List<string> flamable = carGarage
                      .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                      .Select(x => x.Model)
                      .ToList();
            
                  Console.WriteLine(string.Join(Environment.NewLine, flamable));
              }
        }

    }
}
