namespace TheRace.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }
        [Test]
        public void Correctly_Load_Race_Repository()
        {
            var count = this.raceEntry.Counter;

            var expectedCount = 0;

            Assert.That(expectedCount, Is.EqualTo(count));
        }

        [Test]
        public void Increase_Successful_Riders_Count_And_Add_New_Ridr()
        {
            UnitRider unitRider = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 125));
            UnitRider unitRider1 = new UnitRider("TestRider1", new UnitMotorcycle("Honda", 75, 125));

            this.raceEntry.AddRider(unitRider);
            this.raceEntry.AddRider(unitRider1);

            var expectedCount = 2;
            var count = this.raceEntry.Counter;

            Assert.That(expectedCount, Is.EqualTo(count));

        }

        [Test]
        public void Return_Message_For_Case_Add_Rider()
        {
            UnitRider unitRider = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 125));
            var returnMessage = this.raceEntry.AddRider(unitRider);

            var expectedMessage = "Rider TestRider added in race.";

            Assert.That(expectedMessage, Is.EqualTo(returnMessage));


        }

        [Test]
        public void Test_Case_Add_Rider_With_InValid_Rider()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));

        }

        [Test]
        public void Test_Case_Add_Rider_Who_Exists()
        {
            UnitRider unitRider = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 125));

            this.raceEntry.AddRider(unitRider);


            UnitRider unitRider1 = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 125));

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(unitRider1));
        }

        [Test]
        public void Check_Case_Race_With_Less_Than_Two_Riders()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void Calculate_Average_HorsePower_Seccesfully()
        {
            // UnitMotorcycle unitMotorcycle = new UnitMotorcycle()

            UnitRider unitRider = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 125));
            UnitRider unitRider1 = new UnitRider("TestRider1", new UnitMotorcycle("Kawazaki", 65, 105));
            UnitRider unitRider2 = new UnitRider("TestRider2", new UnitMotorcycle("Crosss", 45, 75));

            var power = new List<int>() { 75, 65, 45 };

            this.raceEntry.AddRider(unitRider);
            this.raceEntry.AddRider(unitRider1);
            this.raceEntry.AddRider(unitRider2);

            var averageHorsePower = this.raceEntry.CalculateAverageHorsePower();

            var expextedAverageHorsePower = power.Average();

            Assert.That(expextedAverageHorsePower,Is.EqualTo(averageHorsePower));
        }
    }
}