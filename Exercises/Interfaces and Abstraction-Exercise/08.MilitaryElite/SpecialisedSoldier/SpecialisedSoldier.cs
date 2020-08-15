using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary,string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps 
        {
            get { return this.corps; }
            private set 
            {
                this.corps = value;
            }
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            builder.AppendLine($"Corps: {this.Corps}");

            return builder.ToString().TrimEnd();
        }
    }
}
