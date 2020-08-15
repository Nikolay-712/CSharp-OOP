using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private static double AirConditionersTheirFuelConsumption = 0.9;
        public Car(double fuelQuantity, double litersPerKilometer, double tankCapacity) 
            : base(fuelQuantity, litersPerKilometer, tankCapacity)
        {
            this.LitersPerKilometer = this.LitersPerKilometer + AirConditionersTheirFuelConsumption;
        }

        public override void RefulVehicle(double liters, double fuelQuantity, double tankCapacity)
        {
            base.RefulVehicle(liters, fuelQuantity, tankCapacity);

            this.FuelQuantity = this.FuelQuantity + liters;
        }
    }
}
