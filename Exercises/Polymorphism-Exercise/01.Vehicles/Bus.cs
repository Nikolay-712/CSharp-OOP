using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Bus : Vehicle
    {
        private static double AirConditionersTheirFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double litersPerKilometer, double tankCapacity) 
            : base(fuelQuantity, litersPerKilometer, tankCapacity)
        {
        }

        public override void RefulVehicle(double liters, double fuelQuantity, double tankCapacity)
        {
            base.RefulVehicle(liters, fuelQuantity, tankCapacity);

            this.FuelQuantity = this.FuelQuantity + liters;
        }

        public void CheckConditionOfBus(string typeBus)
        {
            if (typeBus == "Drive")
            {
                this.LitersPerKilometer = this.LitersPerKilometer + AirConditionersTheirFuelConsumption;
            }
           
        }
    }
}
