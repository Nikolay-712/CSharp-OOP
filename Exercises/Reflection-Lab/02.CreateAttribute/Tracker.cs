using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _02.CreateAttribute
{
    public class Tracker
    {
        public  void PrintMethodsByAuthor()
        {
            var targetType = typeof(StartUp);

            MethodInfo[] methodInfo = targetType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var method in methodInfo)
            {
               
                if (method.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute item in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {item.Name}");
                    }
                }
            }
        }

    }
}
