using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gendar) 
            : base(name, age, gendar)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
