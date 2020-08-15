using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {

        private List<Repairs> repairs;

        public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = new List<Repairs>();
        }

        public IReadOnlyCollection<Repairs> Repairs 
        {
            get { return this.repairs; } 
        }

        public void AddRepairs(Repairs repairs)
        {
            this.repairs.Add(repairs);
        }

        public override string ToString()
        {

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ToString());
            builder.AppendLine("Repairs:");

            foreach (Repairs repair in this.repairs)
            {
                builder.AppendLine($"  {repair.ToString()}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
