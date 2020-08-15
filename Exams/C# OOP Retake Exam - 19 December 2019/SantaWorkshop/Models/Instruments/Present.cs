namespace SantaWorkshop.Models.Instruments
{
    using System;

    using SantaWorkshop.Models.Presents.Contracts;
    using SantaWorkshop.Utilities.Messages;

    public class Present : IPresent
    {
        private const int decreasesEnergy = 10;

        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get { return this.energyRequired; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energyRequired = value;
            }
        }

        public void GetCrafted()
        {
            var currentEnergy = this.EnergyRequired - decreasesEnergy;
            if (currentEnergy < 0)
            {
                this.EnergyRequired = 0;
            }
            else
            {
                this.EnergyRequired = this.EnergyRequired - decreasesEnergy;
            }
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }

            return false;
        }
    }
}
