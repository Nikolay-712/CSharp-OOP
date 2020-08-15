using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private double weekSalary;

        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHours)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHours;
        }

        public double WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                ErrorMessagesGenerator.ValidatedWorkingHours(value, nameof(this.workHoursPerDay));
                this.workHoursPerDay = value;
            }
        }


        public double WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                ErrorMessagesGenerator.ValidateWeekSalary(value, nameof(this.weekSalary));
                this.weekSalary = value;
            }
        }

        private double CalculateSalaryPerHour()
        {
            return (this.WeekSalary / 5.0) / this.WorkHoursPerDay;
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString())
                .AppendLine($"Week Salary: {this.weekSalary:f2}")
                .AppendLine($"Hours per day: {this.workHoursPerDay:f2}")
                .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");


            return stringBuilder.ToString().TrimEnd();
        }

    }
}
