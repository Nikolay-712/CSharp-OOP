namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    public class HarvestingFieldsTest
    {

        public static void Main()
        {
            string commands = Console.ReadLine();
            var type = typeof(HarvestingFieldsTest).Assembly.GetTypes().FirstOrDefault(x => x.Name == nameof(HarvestingFields));

            var fieldAccessModifier = string.Empty;
            var fieldTypeName = string.Empty;
            var fieldName = string.Empty;


            while (commands != "HARVEST")
            {
                switch (commands)
                {
                    case "private":

                        var privateFields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                            .Where(x => x.IsPrivate);
                        PrintInfo(privateFields, fieldAccessModifier, fieldTypeName, fieldTypeName);
                        break;
                    case "protected":

                        var protectedFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(x => x.IsFamily);
                        PrintInfo(protectedFields, fieldAccessModifier, fieldTypeName, fieldTypeName);
                        break;
                    case "public":

                        var publicFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public)
                         .Where(x => x.IsPublic);
                        PrintInfo(publicFields, fieldAccessModifier, fieldTypeName, fieldTypeName);
                        break;
                    case "all":

                        var allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField);
                        PrintInfo(allFields, fieldAccessModifier, fieldTypeName, fieldTypeName);
                        break;
                    default:
                        throw new ArgumentException("Not Valid Command");

                }

                commands = Console.ReadLine();
            }


        }

        private static void PrintInfo(IEnumerable<FieldInfo> fields, string fieldAccessModifier, string fieldTypeName, string fieldName)
        {
            foreach (var field in fields)
            {

                fieldAccessModifier = field.Attributes.ToString().ToLower();
                fieldTypeName = field.FieldType.Name;
                fieldName = field.Name;

                if (fieldAccessModifier == "family")
                {
                    fieldAccessModifier = "protected";
                }
                Console.WriteLine($"{fieldAccessModifier} {fieldTypeName} {fieldName}");
            }
        }












    }
}
