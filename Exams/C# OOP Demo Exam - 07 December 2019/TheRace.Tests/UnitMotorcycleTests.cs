namespace TheRace.Tests
{
    using NUnit.Framework;

    public class UnitMotorcycleTests
    {
        private UnitMotorcycle unitMotorcycle;

        [SetUp]
        public void SetUp()
        {
            this.unitMotorcycle = new UnitMotorcycle("Honda",75,150);

        }

        [Test]
        public void Seccesfully_Set_Parameter_Motorcycle_Model()
        {
            var model = this.unitMotorcycle.Model;

            var expectedModel = "Honda";

            Assert.That(expectedModel,Is.EqualTo(model));
        }

        [Test]
        public void Seccesfully_Set_Parameter_Motorcycle_Horse_Power()
        {
            var horsePower = this.unitMotorcycle.HorsePower;

            var expectedHorsePower = 75;

            Assert.That(expectedHorsePower, Is.EqualTo(horsePower));
        }

        [Test]
        public void Seccesfully_Set_Parameter_Motorcycle_Cubic_Centimeters()
        {
            var cubicCentimeters = this.unitMotorcycle.CubicCentimeters;

            var expectedCubicCentimeters = 150;

            Assert.That(expectedCubicCentimeters, Is.EqualTo(cubicCentimeters));
        }
    }
}
