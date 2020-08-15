namespace SantaWorkshop.Models.Dwarfs
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Instruments.Contracts;
    using SantaWorkshop.Utilities.Messages;


    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;
        private readonly IList<IInstrument> instruments;

        protected Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.instruments = new List<IInstrument>();

        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                if (value < 0)
                {
                    value = 0;
                }
                this.energy = value;
            }
        }

        public ICollection<IInstrument> Instruments => this.instruments;

        public void AddInstrument(IInstrument instrument)
        {
            this.instruments.Add(instrument);
        }

        public abstract void Work();

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder
                .AppendLine($"Name: {this.Name}")
                .AppendLine($"Energy: {this.Energy}")
                .AppendLine($"Instruments {this.Instruments.Where(x => x.IsBroken() == false).Count()} not broken left");

            return stringBuilder.ToString().TrimEnd();

        }

    }
}
