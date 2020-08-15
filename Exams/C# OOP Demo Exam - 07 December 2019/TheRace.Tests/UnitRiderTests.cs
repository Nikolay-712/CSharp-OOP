namespace TheRace.Tests
{
    using NUnit.Framework;
    using System;

    public class UnitRiderTests
    {
        [Test]
        public void Seccesfully_Set_Rider_Name()
        {
            UnitRider unitRider = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 150));

            var name = unitRider.Name;

            var expectedName = "TestRider";

            Assert.That(expectedName, Is.EqualTo(name));
        }

        [Test]
        public void Set_Invalid_Name()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitRider(null, new UnitMotorcycle("Honda", 75, 150)));
        }

        [Test]
        public void Seccesfully_Set_Rider_Motorcycle()
        {
            UnitRider unitRider = new UnitRider("TestRider", new UnitMotorcycle("Honda", 75, 150));

            var motorcycleModel = unitRider.Motorcycle.Model;
            var horsePower = unitRider.Motorcycle.HorsePower;
            var cubicCentimeters = unitRider.Motorcycle.CubicCentimeters;

            var expectedMotorcycleModel = "Honda";
            var expectedHorsePower = 75;
            var expectedCubicCentimeters = 150;

            Assert.That(expectedMotorcycleModel, Is.EqualTo(motorcycleModel));
            Assert.That(expectedHorsePower, Is.EqualTo(horsePower));
            Assert.That(expectedCubicCentimeters, Is.EqualTo(cubicCentimeters));

        }
    }
}
