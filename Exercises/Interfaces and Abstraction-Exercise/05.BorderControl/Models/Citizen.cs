using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public class Citizen : Model
    {
        public Citizen(string name,int age,string id, string birthdate)
        {
            base.Name = name;
            base.Age = age;
            base.ID = ID;
            base.Birthdate = birthdate;
        }

       
    }
}
