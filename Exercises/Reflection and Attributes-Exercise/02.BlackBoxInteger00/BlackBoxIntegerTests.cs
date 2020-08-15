namespace P02_BlackBoxInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var AssemblyInfo = typeof(BlackBoxIntegerTests).Assembly.GetTypes().FirstOrDefault(x => x.Name == nameof(BlackBoxInteger));
            var classInstance = Activator.CreateInstance(typeof(BlackBoxInteger), true);
            var methodsList = AssemblyInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            string command = Console.ReadLine();
            StringBuilder builder = new StringBuilder();

            while (command != "END")
            {

                var commandInfo = command.Split("_", StringSplitOptions.RemoveEmptyEntries);

                string methodName = commandInfo[0];
                int value = int.Parse(commandInfo[1]);


                GetCurrentMethod(methodName, methodsList).Invoke(classInstance, new object[] { value });
                var classInstanceField = AssemblyInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(x => x.Name == "innerValue");
                var fieldValue = classInstanceField.GetValue(classInstance);
                builder.AppendLine(fieldValue.ToString());



                command = Console.ReadLine();
            }

            Console.WriteLine(builder.ToString().TrimEnd());
        }

        private static MethodInfo GetCurrentMethod(string methodName, MethodInfo[] methods)
        {
            var currentMethod = methods.FirstOrDefault(x => x.Name == methodName);

            return currentMethod;
        }
    }
}


