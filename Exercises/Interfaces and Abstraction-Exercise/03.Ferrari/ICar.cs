using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    public interface ICar
    {
        public string Model { get; }

        public string DriverName { get; }

        public string PushBrakes();

        public string PushGas();
    }
}
