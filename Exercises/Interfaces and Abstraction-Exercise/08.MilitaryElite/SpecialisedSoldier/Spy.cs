using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName,int codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"{base.ToString()}");
            builder.AppendLine($"Code Number: {this.CodeNumber}");

            return builder.ToString().TrimEnd();
        }
    }
}
