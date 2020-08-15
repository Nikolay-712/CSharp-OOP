using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Repairs
    {
        private string partName;
        private int hoursWorked;

        public Repairs(string partName, int hours)
        {
            this.PartName = partName;
            this.HoursWorked = hours;
        }

        public int HoursWorked
        {
            get { return this.hoursWorked; }
            set { this.hoursWorked = value; }
        }


        public string PartName
        {
            get { return this.partName; }
            set { this.partName = value; }
        }

        public override string ToString()
        {
            return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";

        }
    }
}
