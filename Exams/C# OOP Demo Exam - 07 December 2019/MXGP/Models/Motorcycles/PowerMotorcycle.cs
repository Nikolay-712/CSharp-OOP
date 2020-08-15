namespace MXGP.Models.Motorcycles
{
    using System;

    using MXGP.Utilities.Messages;


    public class PowerMotorcycle : Motorcycle
    {
        private const double cubicCentimeters = 450;
        private const int minimumHorsepower = 70;
        private const int maximumHorsepower = 100;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, cubicCentimeters)
        {
            if (horsePower < minimumHorsepower || horsePower > maximumHorsepower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
