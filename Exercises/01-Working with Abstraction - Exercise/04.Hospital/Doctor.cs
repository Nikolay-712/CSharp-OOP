using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    public class Doctor
    {
        private string fullName;
        private string firstName { get; set; }

        private string secondName { get; set; }

        public Doctor(string firstName,string secondName)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.FullName = this.firstName + this.secondName;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set { this.fullName = value; }
        }

    }
}
