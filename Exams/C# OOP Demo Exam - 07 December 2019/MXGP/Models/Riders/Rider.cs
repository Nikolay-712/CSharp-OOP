namespace MXGP.Models.Riders
{
    using System;

    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;

    public class Rider : IRider
    {
        private const int validMinimalLenghtForRiderName = 5;

        private string name;

        public Rider(string name)
        {
            this.Name = name;
            this.Motorcycle = null;
            this.NumberOfWins = 0;
            this.CanParticipate = false;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (true)
                {
                    if (string.IsNullOrEmpty(value)
                        || string.IsNullOrWhiteSpace(value)
                        || value.Length < validMinimalLenghtForRiderName)
                    {
                        throw new ArgumentException
                            (string.Format(ExceptionMessages.InvalidName, value, validMinimalLenghtForRiderName));
                    }

                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.MotorcycleInvalid));
            }

            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
