namespace MXGP.Models.Races
{
    using System;
    using System.Collections.Generic;

    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;


    public class Race : IRace
    {
        private const int validMinimlaLenghtForRaceName = 5;

        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name,int laps)
        {
            this.Name = name;
            this.laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name 
        {
            get { return this.name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) 
                    || string .IsNullOrEmpty(value) 
                    || value.Length < validMinimlaLenghtForRaceName)
                {
                    throw new ArgumentException
                        (string.Format(ExceptionMessages.InvalidName, value, validMinimlaLenghtForRaceName));
                }

                this.name = value;
            }
        }

        public int Laps 
        {
            get { return this.laps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps,laps));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders 
        {
            get { return this.riders.AsReadOnly(); }
        }

        public void AddRider(IRider rider)
        {
            if ( rider == null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderInvalid));
            }

            if (rider.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }

            if (this.riders.Contains(rider))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
