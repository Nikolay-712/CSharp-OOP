using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Human
    {
        private static int MinFirstNameLenght = 4;
        private static int MinLastNameLenght = 3;

        private string firstName;

        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                ErrorMessagesGenerator.ValidateName(value, nameof(this.lastName));
                ErrorMessagesGenerator.ValidateNameLenght(value, nameof(this.lastName), MinLastNameLenght);

                this.lastName = value;
            }
        }


        public string FirstName
        {
            get { return this.firstName; }
            private set
            {

                ErrorMessagesGenerator.ValidateName(value, nameof(this.firstName));
                ErrorMessagesGenerator.ValidateNameLenght(value, nameof(this.firstName), MinFirstNameLenght);

                this.firstName = value;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"First Name: {this.firstName}").AppendLine($"Last Name: {this.lastName}");

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
