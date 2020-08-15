using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public abstract class Vehicle  : VehicleFunctional
    {
        private double fuelQuantity;
        private double litersPerKilometer;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double litersPerKilometer, double tankCapacity)
        {
            this.FuelQuantity = VehicleFunctional.CheckTheInitialQuantity(fuelQuantity,tankCapacity);
            this.LitersPerKilometer = litersPerKilometer;
            this.TankCapacity = tankCapacity;
        }

        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set { tankCapacity = value; }

        }


        public double LitersPerKilometer
        {
            get { return this.litersPerKilometer; }
            protected set { this.litersPerKilometer = value; }
        }


        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set { this.fuelQuantity = value; }

        }

        public string Drive(double distance)
        {
            var fuelForDistance = VehicleFunctional.DriveVehicle(distance,this.LitersPerKilometer);
            var type = this.GetType().Name;

            if (fuelForDistance > this.FuelQuantity)
            {
                return $"{type} needs refueling";
            }
            else
            {
                this.FuelQuantity = this.FuelQuantity - fuelForDistance;
                return $"{type} travelled {distance} km";
               
            }
        }

    }
}
