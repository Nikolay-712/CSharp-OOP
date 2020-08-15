using System;

namespace LoggerInfo
{
    public class Program
    {
        static void Main()
        {
            SimpleLayout simpleLayout = new SimpleLayout();

            string info = string.Format(simpleLayout.Format,"data","level","info");
            Console.WriteLine(info);

            ConsoleAppender consoleAppender = new ConsoleAppender(simpleLayout);
        }
    }
}
