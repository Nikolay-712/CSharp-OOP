namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("Akvarium", 5);
        }

        [Test]
        public void Correctly_Set_Of_Aquarium_Name()
        {
            var expectedName = "Akvarium";

            Assert.That(expectedName, Is.EqualTo(this.aquarium.Name));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Case_Initialize_Aquarium_Wit_Invalid_Parameter_Name(string invalidParameter)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(invalidParameter, 10));
        }

        [Test]
        public void Correctly_Set_Of_Aquarium_Capacity()
        {
            var expectedCapacity = 5;

            Assert.That(expectedCapacity, Is.EqualTo(this.aquarium.Capacity));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        [TestCase(-100)]
        public void Test_Case_Initialize_Aquarium_Wit_Invalid_Parameter_Capacity(int invalidParameter)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Akvarium", invalidParameter));
        }

        [Test]
        public void Correctly_Set_Of_Fish_Colection_In_Aquarium()
        {
            var expectedFishCount = 0;

            Assert.That(expectedFishCount, Is.EqualTo(this.aquarium.Count));
        }

        [Test]
        public void Test_Case_Add_Fish_In_Aquarium_Successfully()
        {
            Fish fish = new Fish("Ribe");

            this.aquarium.Add(fish);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.aquarium.Count));
        }

        [Test]
        public void Test_Case_Add_New_Fish_In_Full_Aquarium()
        {
            Fish fish = new Fish("Ribe");

            for (int i = 0; i < 5; i++)
            {
                this.aquarium.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(fish));

        }

        [Test]
        public void Test_Case_Remove_Fish_Successfully()
        {
            Fish fish = new Fish("Ribe");

            for (int i = 0; i < 5; i++)
            {
                this.aquarium.Add(fish);
            }

            this.aquarium.RemoveFish("Ribe");

            var expectedCount = 4;

            Assert.That(expectedCount, Is.EqualTo(this.aquarium.Count));
        }

        [Test]
        public void Test_Case_Remove_Fish_With_Not_Existing_Fish()
        {
            Fish fish = new Fish("Ribe");

            for (int i = 0; i < 5; i++)
            {
                this.aquarium.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Prasea"));
        }

        [Test]
        public void Test_Case_Sell_Fish_Successfully()
        {
            Fish fish = new Fish("Ribe");

            this.aquarium.Add(fish);

            var sellFish = this.aquarium.SellFish("Ribe");

            Assert.IsFalse(fish.Available);
            Assert.IsInstanceOf(typeof(Fish),sellFish);
        }

        [Test]
        public void Test_Case_Sell_Not_Existing_Fish()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Ribe"));
        }

        [Test]
        public void Aquarium_Report_ReturnMessage()
        {
            Fish fish = new Fish("TestRiba0");
            Fish fish1 = new Fish("TestRiba1");
            Fish fish2 = new Fish("TestRiba2");

            this.aquarium.Add(fish);
            this.aquarium.Add(fish1);
            this.aquarium.Add(fish2);

            var expectedMessage = $"Fish available at {this.aquarium.Name}: TestRiba0, TestRiba1, TestRiba2";
            var returnMessage = this.aquarium.Report();

            Assert.That(expectedMessage, Is.EqualTo(returnMessage));

        }

        [Test]
        public void Empty_Aquarium_Report()
        {
            var expectedMessage = $"Fish available at {this.aquarium.Name}: ";
            var returnMessage = this.aquarium.Report();

            Assert.That(expectedMessage, Is.EqualTo(returnMessage));
        }
    }
}
