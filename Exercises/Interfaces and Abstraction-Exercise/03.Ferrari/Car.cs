using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Ferrari
{
    public class Car : ICar
    {

        public Car(string name)
        {
            this.DriverName = name;
        }

        public string Model => "488-Spider";

        public string DriverName { get; }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGas()
        {
            return "Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.PushBrakes()}/{this.PushGas()}/{this.DriverName}";
        }
    }
}
