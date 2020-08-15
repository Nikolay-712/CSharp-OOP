namespace StorageMaster.Tests
{
    using System;

    using NUnit.Framework;
    using StorageMaster.Entities.Factories;

    public class VehiclesFactoryTests
    {
        private VehicleFactory vehicleFactory;

        [SetUp]
        public void TestFactory()
        {
            this.vehicleFactory = new VehicleFactory();
        }

        [Test]
        [TestCase("BMW")]
        [TestCase("Mecedes")]
        [TestCase("Audi")]
        [TestCase("Porshe")]
        public void Create_Vehicle_With_Invalid_Type(string type)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.vehicleFactory.CreateVehicle(type)).Message;

            Console.WriteLine(ex);
        }

        [Test]
        [TestCase("Semi")]
        [TestCase("Truck")]
        [TestCase("Van")]
        public void Create_Vehicle_Correctly(string type)
        {
            var currentVehicle = this.vehicleFactory.CreateVehicle(type);
            var vehicleType = currentVehicle.GetType();

            Assert.IsInstanceOf(vehicleType, currentVehicle);
        }
    }
}
