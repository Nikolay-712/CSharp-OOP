using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite
{
    public class Missions
    {
        private string codeName;
        private string state;

        public Missions(string codeName, string state)
        {
            this.codeName = codeName;
            this.State = state;
        }

        public string State
        {
            get { return this.state; }
            private set { this.state = value; }
        }


        public string CodeName
        {
            get { return this.codeName; }
            private set { this.codeName = value; }
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";

        }

    }
}
