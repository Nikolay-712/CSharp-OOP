using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public class Animal
    {
		private string name;
		private int age;
		private string gender;

		public Animal(string name,int age,string gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}

		public string Gender
		{
			get { return this.gender; }
			set { this.CheckInputValues(value); this.gender = value; }
		}


		public int Age
		{
			get { return this.age; }
			set 
			{
				var valueAge = age.ToString();
				this.CheckInputValues(valueAge);

				if (!char.IsDigit(valueAge,0) || value <= 0)
				{
					throw new ArgumentException("Invalid input!");
				}

				this.age = value;
			}
		}

		public string Name
		{
			get { return this.name; }
			set { this.CheckInputValues(value); this.name = value; }
		}

		private void CheckInputValues(string value)
		{
			if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Invalid input!");
			}
		}

		public virtual string ProduceSound()
		{
			return null;
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();

			builder.AppendLine(this.GetType().Name)
			.AppendLine($"{this.name} {this.age} {this.gender.ToString()}")
			.Append($"{this.ProduceSound()}");

			return builder.ToString();
		}

	}
}
