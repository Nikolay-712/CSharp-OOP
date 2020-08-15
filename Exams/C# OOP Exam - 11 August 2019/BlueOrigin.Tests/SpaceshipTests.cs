namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            this.spaceship = new Spaceship("TestName", 5);
        }

        [Test]
        public void Correctly_Set_Parameter_Name()
        {
            var expectedName = "TestName";
            Assert.That(expectedName, Is.EqualTo(this.spaceship.Name));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Test_Case_Initialize_New_Spaceship_With_Invalid_Name(string invalidName)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(invalidName, 5));
        }

        [Test]
        public void Correctly_Set_Parameter_Capacity()
        {
            var expectedCapacity = 5;
            Assert.That(expectedCapacity, Is.EqualTo(this.spaceship.Capacity));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void Test_Case_Initialize_New_Spaceship_With_Invalid_Capacity(int invalidCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("TestName", invalidCapacity));
        }

        [Test]
        public void Correctly_Set_Parameter_Astronauts()
        {
            var expectedCount = 0;
            Assert.That(expectedCount, Is.EqualTo(this.spaceship.Count));
        }

        [Test]
        public void Test_Case_Add_Astronaut_Seccesfully()
        {
            Astronaut astronaut = new Astronaut("Kole",5.5);

            this.spaceship.Add(astronaut);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.spaceship.Count));
        }

        [Test]
        public void Test_Case_Add_Astronaut_When_The_Collection_Is_Full()
        {
            Astronaut astronaut1 = new Astronaut("Kole", 5.5);
            Astronaut astronaut2 = new Astronaut("Olle", 5.5);
            Astronaut astronaut3 = new Astronaut("Vlade", 5.5);
            Astronaut astronaut4 = new Astronaut("Gagarin", 5.5);
            Astronaut astronaut5 = new Astronaut("G.dimitrov", 5.5);

            this.spaceship.Add(astronaut1);
            this.spaceship.Add(astronaut2);
            this.spaceship.Add(astronaut3);
            this.spaceship.Add(astronaut4);
            this.spaceship.Add(astronaut5);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("Laika",3.4)));
        }

        [Test]
        public void Test_Case_Add_Astronaut_When_Exists_In_Colection()
        {
            Astronaut astronaut = new Astronaut("Kole", 5.5);

            this.spaceship.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(new Astronaut("Kole", 2.5)));
        }

        [Test]
        public void Test_Case_Remove_Astronaut_Seccesfully()
        {
            Astronaut astronaut = new Astronaut("Kole", 5.5);

            this.spaceship.Add(astronaut);

            Assert.IsTrue(this.spaceship.Remove("Kole"));
        }

        [Test]
        public void Test_Case_Remove_Astronaut_Wen_Dont_Exsist()
        {
            Astronaut astronaut = new Astronaut("Kole", 5.5);

            this.spaceship.Add(astronaut);

            var expectedCount = 1;

            Assert.IsFalse(this.spaceship.Remove("Laika"));
            Assert.That(expectedCount, Is.EqualTo(this.spaceship.Count));
        }

    }
}