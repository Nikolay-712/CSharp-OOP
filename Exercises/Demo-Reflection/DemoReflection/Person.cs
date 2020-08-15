using System;
using System.Collections.Generic;
using System.Text;

namespace DemoReflection
{
    class Person
    {
		private string firstName;
		private string lastName;
		private int age;

		
		public Person(string firtsName,string lastName,int age)
		{
			this.FirstNmae = firtsName;
			this.LastName = lastName;
			this.Age = 25;
		}

		public Person(string firtsName, string lastName) 
		{
			this.FirstNmae = firtsName;
			this.LastName = lastName;
		}

		private Person()
		{

		}


		public int Age
		{
			get { return this. age; }
			set { this.age = value; }
		}


		public string LastName
		{
			get { return this.lastName; }
			set { this.lastName = value; }
		}


		public string FirstNmae
		{
			get { return this.firstName; }
			set { this.firstName = value; }
		}

		private string CheckFirstName()
		{
			return this.FirstNmae;
		}

		private int CheckPersonAge()
		{
			return this.Age;
		}


	}
}
