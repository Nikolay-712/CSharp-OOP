using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            ParseComands.Run();

            string command = Console.ReadLine();
            Garage.ShowCurrentCar(command);

        }
    }
}
