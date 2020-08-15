using System;
using System.Linq;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main()
        {
            var carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).Skip(1).ToArray();
            var truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).Skip(1).ToArray();
            var busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).Skip(1).ToArray();

            Car car = new Car(carInfo[0], carInfo[1], carInfo[2]);
            Truck truck = new Truck(truckInfo[0], truckInfo[1], truckInfo[2]);
            Bus bus = new Bus(busInfo[0], busInfo[1], busInfo[2]);

            int countComands = int.Parse(Console.ReadLine());

            for (int count = 0; count < countComands; count++)
            {
                var comand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    switch (comand[1])
                    {
                        case "Car":
                            RunVehicle(car, comand[0], comand);
                            break;
                        case "Truck":
                            RunVehicle(truck, comand[0], comand);
                            break;
                        case "Bus":
                            bus.CheckConditionOfBus(comand[0]);
                            RunVehicle(bus, comand[0], comand);
                            break;
                        default:
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");

        }


        private static void RunVehicle(Vehicle vehicle, string comand, string[] info)
        {
            switch (comand)
            {
                case "Refuel":
                    double liters = double.Parse(info[2]);
                    vehicle.RefulVehicle(liters, vehicle.FuelQuantity, vehicle.TankCapacity);
                    break;
                case "Drive":
                    double distance = double.Parse(info[2]);
                    Console.WriteLine(vehicle.Drive(distance));
                    break;
                case "DriveEmpty":
                    distance = double.Parse(info[2]);
                    Console.WriteLine(vehicle.Drive(distance));
                    break;
            }
        }






    }
}
