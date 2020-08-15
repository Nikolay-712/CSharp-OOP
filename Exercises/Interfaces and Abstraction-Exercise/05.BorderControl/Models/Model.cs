using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BorderControl
{
    public abstract class Model : IModelNameInfo, IModelIdInfo, IModelBirthdateInfo, IBuyer
    {
        public virtual string Birthdate { get; set; }

        public virtual string ID { get; set; }

        public virtual string Name { get; set; }

        public virtual int Age { get; set; }

        public int Food { get; set; }

        public static Citizen CitizenCreator(string name, int age, string id, string birthDate)
        {
            return new Citizen(name, age, id, birthDate);
        }

        public static Robot RobotCreator(string model, string id)
        {
            return new Robot(model, id);
        }

        public static Pet PetCreator(string name, string birthDate)
        {
            return new Pet(name, birthDate);
        }

        public static Rebel RebelCreator(string name,int age,string group)
        {
            return new Rebel(name,age,group);
        }

        public void BuyFood()
        {
            var type = GetType().Name;

            if (type == "Citizen")
            {
                Food = Food + 10;
            }
            else if (type == "Rebel")
            {
                Food = Food + 5;
            }

        }

       
    }
}
