namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone("SmartPhone", "Motorola");
        }

        [Test]
        public void Correctly_Set_Of_Phone_Parameters()
        {
            var expectedMake = "SmartPhone";
            var expectedModel = "Motorola";

            Assert.That(expectedMake, Is.EqualTo(this.phone.Make));
            Assert.That(expectedModel, Is.EqualTo(this.phone.Model));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Test_Case_Create_Phone_With_InValid_Parameter_Make(string inValidParameter)
        {
            Assert.Throws<ArgumentException>(() => new Phone(inValidParameter, "Nokia"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Test_Case_Create_Phone_With_InValid_Parameter_Modele(string inValidParameter)
        {
            Assert.Throws<ArgumentException>(() => new Phone("SmartPhone", inValidParameter));
        }

        [Test]
        public void Correctly_Set_Phone_Book()
        {
            var expectedCount = 0;

            Assert.That(expectedCount, Is.EqualTo(this.phone.Count));
        }

        [Test]
        public void Successfully_Adding_Phone_Number_And_Check_PhoneBook_Count()
        {
            var contactName = "Kole";
            var phoneNumber = "0899900888";

            this.phone.AddContact(contactName, phoneNumber);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(phone.Count));
        }

        [Test]
        public void Check_Name_And_Phone_Number_In_Phone_Book()
        {
            var contactName = "Kole";
            var phoneNumber = "0899900888";

            this.phone.AddContact(contactName, phoneNumber);

            var phoneBook = typeof(Phone)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "phonebook")
                .GetValue(phone) as Dictionary<string,string>;

            
            var actualPhoneNumber = phoneBook["Kole"];
           
            Assert.That(phoneNumber, Is.EqualTo(actualPhoneNumber));

        }

        [Test]
        public void Add_Contact_Who_Exists_In_Phone_Book()
        {
            var contactName = "Kole";
            var phoneNumber = "0899900888";

            this.phone.AddContact(contactName, phoneNumber);

            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact("Kole", "0888888899989"));
        }

        [Test]
        public void Successful_Call_To_Existing_Phone_Number()
        {
            var contactName = "Kole";
            var phoneNumber = "0899900888";

            this.phone.AddContact(contactName, phoneNumber);

            var expectedMessage = $"Calling {contactName} - {phoneNumber}...";

            Assert.That(expectedMessage, Is.EqualTo(this.phone.Call("Kole")));
        }

        [Test]
        public void Call_Missing_Phone_Number()
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call("Kole"));
        }
    }
}