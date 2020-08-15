namespace StorageMaster.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    public class VehicleVanTests
    {
        private Vehicle vehicle;

        [SetUp]
        public void InitializeVehicle()
        {
            this.vehicle = new Van();
        }

        [Test]
        public void Correctly_Set_Of_Track_Capacity()
        {
            var defaultTruckCapacity = 2;
            Assert.That(defaultTruckCapacity, Is.EqualTo(this.vehicle.Capacity));
        }

        [Test]
        public void Initialize_Correctly_Vehicle_Trunk()
        {
            bool isCorect = (this.vehicle.Trunk != null);

            Assert.IsTrue(isCorect);
        }

        [Test]
        public void Check_For_Successful_Implementation_Of_Method_LoadProduct()
        {
            Product product = new HardDrive(4.5);
            var productsCount = 2;

            for (int i = 1; i <= productsCount; i++)
            {
                this.vehicle.LoadProduct(product);
            }

            var productsInTrunk = this.vehicle.Trunk.Count;
            Assert.That(productsCount, Is.EqualTo(productsInTrunk));
        }

        [Test]
        public void Check_For_Trunk_Capacity_Is_Full()
        {
            Product product = new HardDrive(4.5);
            var productsCount = 2;

            for (int i = 1; i <= productsCount; i++)
            {
                this.vehicle.LoadProduct(product);
            }

            var ex = Assert.Throws<InvalidOperationException>(() => this.vehicle.LoadProduct(product)).Message;
            Console.WriteLine(ex);

        }
        [Test]
        public void Check_For_Successful_Implementation_Of_Method_UnloadProducts()
        {
            Product product = new HardDrive(4.5);
            var productsCount = 1;

            for (int i = 1; i <= productsCount; i++)
            {
                this.vehicle.LoadProduct(product);
            }

            var lastProductInTrunk = new Gpu(2.5);
            this.vehicle.LoadProduct(lastProductInTrunk);

            var unloadProduct = vehicle.Unload();

            Assert.AreSame(lastProductInTrunk, unloadProduct);

        }

        [Test]
        public void Check_For_Trunk_Is_Empty()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.vehicle.Unload()).Message;
            Console.WriteLine(ex);

        }

        [Test]
        public void Correct_Calculation_Of_Weight_Of_Products_In_Trunk()
        {
            Product product = new HardDrive(4.5);
            var productsCount = 2;

            for (int i = 1; i <= productsCount; i++)
            {
                this.vehicle.LoadProduct(product);
            }

            var expectedWeight = 2;
            var tottalWeightInTrunk = this.vehicle.Trunk.Sum(c => c.Weight);

            Assert.That(expectedWeight, Is.EqualTo(tottalWeightInTrunk));
        }
    }
}
