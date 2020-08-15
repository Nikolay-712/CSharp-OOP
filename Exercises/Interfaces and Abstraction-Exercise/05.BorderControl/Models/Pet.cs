using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Pet : Model
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public override string Name { get => base.Name; set => base.Name = value; }

        public override string Birthdate { get => base.Birthdate; set => base.Birthdate = value; }

    }
}
