using System;

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            Animal cat = new Cat("Pesho", "Wiskas");
            Animal dog = new Dog("Gosho", "Meet");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
