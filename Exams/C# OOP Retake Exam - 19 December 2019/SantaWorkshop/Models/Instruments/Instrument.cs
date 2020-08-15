namespace SantaWorkshop.Models.Instruments
{
    using SantaWorkshop.Models.Instruments.Contracts;

    public class Instrument : IInstrument
    {
        private const int decreasesPower = 10;

        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get { return this.power; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                this.power = value;
            }
        }

        public bool IsBroken()
        {
            if (this.Power == 0)
            {
                return true;
            }

            return false;
        }

        public void Use()
        {
            var currentEnergy = this.Power - decreasesPower;
            if (currentEnergy < 0)
            {
                this.Power = 0;
            }
            else
            {
                this.Power = this.Power - decreasesPower;
            }
        }
    }
}
