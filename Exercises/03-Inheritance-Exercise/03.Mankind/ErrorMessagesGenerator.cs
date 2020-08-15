using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace _03.Mankind
{
    public static class ErrorMessagesGenerator
    {

        private static string InValidName = "Expected upper case letter! Argument: ";

        private static string InValidLenghtName = "Expected length at least 4 symbols! Argument: ";

        private static string InvalidFacultyNumber = "Invalid faculty number!";

        private static string InValidWeekSalary = "Expected value mismatch! Argument: ";

        private static string InValidWorkingHours = "Expected value mismatch! Argument: ";

        public static void ValidateFacultyNumber(string number)
        {
            if (number.Length < 5 || number.Length > 10 || !number.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException(InvalidFacultyNumber);
            }
        }

        public static void ValidateWeekSalary(double salary, string parameterName)
        {
            if (salary <= 10)
            {
                throw new ArgumentException(InValidWeekSalary + parameterName);
            }
        }

        public static void ValidatedWorkingHours(double hours, string parameterName)
        {
            if (hours < 1 || hours > 12)
            {
                throw new ArgumentException(InValidWorkingHours + parameterName);
            }
        }

        public static void ValidateName(string name, string parameterName)
        {
            if (!char.IsUpper(name[0]))
            {
                throw new ArgumentException(InValidName + parameterName);
            }
        }

        public static void ValidateNameLenght(string name , string parameterName,int lenght) 
        {
            if (name.Length < lenght)
            {
                throw new ArgumentException(InValidLenghtName + parameterName);
            }

        }
    }
}
