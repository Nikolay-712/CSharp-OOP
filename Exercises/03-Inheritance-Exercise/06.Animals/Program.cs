using System;
using System.Collections.Generic;

namespace _06.Animals
{
    public class Program
    {
        static void Main()
        {

            var animalsList = new List<Animal>();
            string typeAnimal = Console.ReadLine();

            while (typeAnimal != "Beast!")
            {
                var tokens = Console.ReadLine().Split();

                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var gender = tokens[2];

                try
                {
                    switch (typeAnimal)
                    {
                        case "Dog":
                            animalsList.Add(new Dog(name, age, gender));
                            break;
                        case "Cat":
                            animalsList.Add(new Cat(name, age, gender));
                            break;
                        case "Frog":
                            animalsList.Add(new Frog(name, age, gender));
                            break;
                        case "Kittens":
                            animalsList.Add(new Kitten(name, age, gender));
                            break;
                        case "Tomcat":
                            animalsList.Add(new Tomcat(name, age, gender));
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                typeAnimal = Console.ReadLine();

            }

            animalsList.ForEach(Console.WriteLine);
        }
    }
}
