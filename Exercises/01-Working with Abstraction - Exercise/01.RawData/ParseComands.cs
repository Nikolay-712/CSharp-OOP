using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class ParseComands
    {
        public static void Run()
        {
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                var engine = CarFactory.AddEngine(engineSpeed, enginePower);


                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                var cargo = CarFactory.AddCargo(cargoWeight, cargoType);

                var tiresInfo = parameters.Skip(5).ToArray();

                var tires = CarFactory.AddTires(tiresInfo);

                CarFactory.AddNewCarInGarage(model, engine, cargo, tires);

            }
        }
    }
}
