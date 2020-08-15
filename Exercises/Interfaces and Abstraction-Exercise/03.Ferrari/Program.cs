using System;

namespace _03.Ferrari
{
    public class Program
    {
        static void Main()
        {
            string name = Console.ReadLine();

            ICar car = new Car(name);

            Console.WriteLine(car);
        }
    }
}
