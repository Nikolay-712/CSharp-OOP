namespace AquaShop.Models.Aquariums
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int confort;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Decorations = new List<IDecoration>();
            this.Fish = new List<IFish>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }
        public int Capacity { get; private set; }

        public int Comfort
        {
            get { return this.Decorations.Select(x => x.Comfort).Sum(); }
            private set { this.confort = value; }
        }

        public ICollection<IDecoration> Decorations { get; private set; }

        public ICollection<IFish> Fish { get; private set; }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.Fish.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.Fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder builder = new StringBuilder();
            var fishInAquarium = "none";

            if (this.Fish.Count != 0)
            {
                fishInAquarium = string.Join(", ", this.Fish.Select(x => x.Name));
            }

            builder
                .AppendLine($"{this.name} ({this.GetType().Name}):")
                .AppendLine($"Fish: {fishInAquarium}")
                .AppendLine($"Decorations: {this.Decorations.Count}")
                .AppendLine($"Comfort: {this.Comfort}");

            return builder.ToString().TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        {
            var isRemoved = this.Fish.Remove(fish);

            return isRemoved;
        }
    }
}
