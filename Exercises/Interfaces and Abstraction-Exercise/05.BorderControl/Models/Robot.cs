using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Robot : Model
    {
        public Robot(string model, string id)
        {
            this.Name = model;
            this.ID = id;
        }

        public override string Name { get => base.Name; set => base.Name = value; }

        public override string ID { get => base.ID; set => base.ID = value; }
    }
}
