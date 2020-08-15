using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set { IsValidSalaryValue(value); this.salary = value; }
        }


        public int Age
        {
            get { return this.age; }
            set { this.IsValidAge(value); this.age = value; }

        }


        public string LastName
        {
            get { return this.lastName; }
            set { this.IsValidName(value); this.lastName = value; }

        }


        public string FirstName
        {
            get { return this.firstName; }
            set { this.IsValidName(value); this.firstName = value; }

        }

        private void IsValidName(string name)
        {
            if (name.Length < 3)
            {
                throw new ArgumentException("Names must be at least 3 symbols!");
            }
        }
        private void IsValidAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
        }

        private void IsValidSalaryValue(decimal salary)
        {
            if (salary < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";

        }

    }
}
