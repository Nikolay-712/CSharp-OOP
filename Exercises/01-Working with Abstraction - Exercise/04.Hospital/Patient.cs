using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Patient
    {
        private string name;

        public Patient(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

    }
}
