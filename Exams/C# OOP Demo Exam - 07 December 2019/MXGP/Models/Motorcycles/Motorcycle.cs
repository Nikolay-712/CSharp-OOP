namespace MXGP.Models.Motorcycles
{
    using System;

    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;


    public abstract class Motorcycle : IMotorcycle
    {
        private const int validMinimalLenghtForModelName = 4;
        private string model;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrEmpty(value)
                    || string.IsNullOrWhiteSpace(value)
                    || value.Length < validMinimalLenghtForModelName)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidModel, value, validMinimalLenghtForModelName));
                }
                this.model = value;
            }
        }

        public int HorsePower { get; }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var racePoints = (this.CubicCentimeters / this.HorsePower) * laps;
            return racePoints;
        }
    }
}
