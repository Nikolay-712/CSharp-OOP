namespace MXGP.Models.Motorcycles
{
    using System;

    using MXGP.Utilities.Messages;


    public class SpeedMotorcycle : Motorcycle
    {
        private const double cubicCentimeters = 125;
        private const int minimumHorsepower = 50;
        private const int maximumHorsepower = 69;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, cubicCentimeters)
        {

            if (horsePower < minimumHorsepower || horsePower > maximumHorsepower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
