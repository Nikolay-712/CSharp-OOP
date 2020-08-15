using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class VehicleFunctional
    {
        protected static double CheckTheInitialQuantity(double initialQuantity, double tankCapacity)
        {
            if (initialQuantity > tankCapacity)
            {
                return 0;
            }

            return initialQuantity;
        }

        protected static double DriveVehicle(double distance, double litersPerKm)
        {
            var needFuel = distance * litersPerKm;
            return needFuel;

        }

        public virtual void RefulVehicle(double liters, double fuelQuantity, double tankCapacity)
        {
            var newQuantity = liters + fuelQuantity;

            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (newQuantity > tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
        }
    }
}
