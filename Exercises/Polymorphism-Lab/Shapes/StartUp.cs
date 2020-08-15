using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Shape ractengle = new Rectangle(5,4);

            Shape circle = new Circle(5);

            Console.WriteLine(ractengle.Draw());
            Console.WriteLine(circle.Draw());

          
        }
    }
}
