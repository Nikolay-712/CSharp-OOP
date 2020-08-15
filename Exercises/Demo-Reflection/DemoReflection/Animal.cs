using System;
using System.Collections.Generic;
using System.Text;

namespace DemoReflection
{
    class Animal
    {
        private string name;
        private string breed;
        private int weight;

        public Animal(string name, string breed, int weight)
        {
            this.Name = name;
            this.Breed = breed;
            this.Weight = weight;
        }
        public Animal(string breed, int weight)
        {
            this.Breed = breed;
            this.Weight = weight;
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }


        public string Breed
        {
            get { return this.breed; }
            set { this.breed = value; }
        }


        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        private string Sound()
        {
            return "Sound......";
        }

        private int CalculateWeight()
        {
            return this.Weight;
        }
    }
}
