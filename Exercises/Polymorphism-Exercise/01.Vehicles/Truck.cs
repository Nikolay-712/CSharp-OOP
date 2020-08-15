using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private static double AirConditionersTheirFuelConsumption = 1.6;
        public Truck(double fuelQuantity, double litersPerKilometer, double tankCapacity)
            : base(fuelQuantity, litersPerKilometer, tankCapacity)
        {
            this.LitersPerKilometer = this.LitersPerKilometer + AirConditionersTheirFuelConsumption;
        }

        private double CalculateTheLostFuel(double liters)
        {
            var fuel = liters * 5 / 100;
            return fuel;
        }
        public override void RefulVehicle(double liters, double fuelQuantity, double tankCapacity)
        {
            base.RefulVehicle(liters, fuelQuantity, tankCapacity);
            liters = liters - CalculateTheLostFuel(liters);

            this.FuelQuantity = this.FuelQuantity + liters;
        }
    }
}
