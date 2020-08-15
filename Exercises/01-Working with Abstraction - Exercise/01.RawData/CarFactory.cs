using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class CarFactory
    {
        public static Engine AddEngine(int engineSpeed, int enginePower)
        {
            return new Engine(engineSpeed, enginePower);
        }

        public static Cargo AddCargo(int cargoWeight, string cargoType)
        {
            return new Cargo(cargoWeight, cargoType);
        }

        public static Tires AddTires(string[] tiresInfo)
        {
            return new Tires(tiresInfo);
        }

        public static void AddNewCarInGarage(string model, Engine engine, Cargo cargo, Tires tires)
        {
            Garage.AddCarInGarage(new Car(model, engine, cargo, tires));
        }
    }
}
