namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;

    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Bags;
    using SpaceStation.Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        
        protected Astronaut(string name,double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }


        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get { return this.oxygen; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag { get; }

        public virtual void Breath()
        {
            var neededOxygen = this.Oxygen - 10;

            if (neededOxygen < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen = this.Oxygen - 10;
            }

        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            var itemsInBag = "none";

            if (this.Bag.Items.Count != 0)
            {
                 itemsInBag = string.Join(", ", this.Bag.Items);
            }

            builder
                .AppendLine($"Name: {this.name}")
                .AppendLine($"Oxygen: {this.Oxygen}")
                .AppendLine($"Bag items: {itemsInBag}");


            return builder.ToString().TrimEnd();
        }

    }
}
