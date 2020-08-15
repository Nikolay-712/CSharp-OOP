using System;
using System.Reflection;
using System.Linq;

namespace DemoReflection
{
    public class Program
    {
        static void Main(string[] args)
        {
            var personInfo = typeof(Program).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Person");
            var animalInfo = typeof(Program).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Animal");

            var constructors = personInfo.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var properties = personInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var methods = personInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            var fields = personInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

           
           
         


        }
    }
}
