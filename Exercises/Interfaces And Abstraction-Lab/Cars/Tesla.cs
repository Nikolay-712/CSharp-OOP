using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        public Tesla(string model, string color, int batteries)
            : base(model, color)
        {
            this.Battery = batteries;
        }



        public int Battery { get; }

        protected override string BaseCarInfo()
        {
            return $"{base.BaseCarInfo()} with {this.Battery} Batteries";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
