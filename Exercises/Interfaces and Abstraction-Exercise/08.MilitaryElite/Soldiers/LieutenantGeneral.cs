using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> privates;

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<Private>();
        }

        public IReadOnlyCollection<Private> Privates
        {
            get { return this.privates; }

        }

        public void AddSoldier(Private @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{base.ToString()}").AppendLine("Privates:");

            foreach (Private @private in this.privates)
            {
                builder.AppendLine($"  {@private.ToString()}");
            }

            return builder.ToString().TrimEnd();
        }
    }
}
