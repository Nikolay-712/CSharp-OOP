using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Rebel : Model
    {
        public Rebel(string name, int age ,string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;

        }

        public override string Name { get => base.Name; set => base.Name = value; }

        public override int Age { get => base.Age; set => base.Age = value; }

        public string Group { get; private set; }

       
    }
}
