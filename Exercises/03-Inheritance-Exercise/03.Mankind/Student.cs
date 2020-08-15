using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Student : Human
    {
		private string facultyNumber;

		public Student(string firstName, string lastName ,string facultyNumber) 
			: base(firstName, lastName)
		{
			this.FacultyNumber = facultyNumber;
		}

		public string FacultyNumber
		{
			get { return this.facultyNumber; }
			private set
			{
				ErrorMessagesGenerator.ValidateFacultyNumber(value);
				this.facultyNumber = value; 
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.AppendLine(base.ToString()).AppendLine($"Faculty number: {this.facultyNumber}");

			return stringBuilder.ToString();
		}
	}
}
