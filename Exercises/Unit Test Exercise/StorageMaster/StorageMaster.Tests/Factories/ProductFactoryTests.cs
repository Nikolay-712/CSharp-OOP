namespace StorageMaster.Tests
{
    using System;

    using NUnit.Framework;
    using StorageMaster.Entities.Factories;
    

    public class ProductFactoryTests
    {
        private ProductFactory productFactory;

        [SetUp]
        public void TestFactory()
        {
            this.productFactory = new ProductFactory();
        }


        [Test]
        [TestCase("Gpus", 5)]
        [TestCase("HardDrivePro", 5)]
        [TestCase("Ram123", 5)]
        [TestCase("SolidState", 5)]
        public void Create_Product_With_Invalid_Type(string type, double price)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.productFactory.CreateProduct(type, price)).Message;

            Console.WriteLine(ex);
        }

        [Test]
        [TestCase("Gpu", -5)]
        [TestCase("HardDrive", -15)]
        [TestCase("Ram", -225)]
        [TestCase("SolidStateDrive", -1)]
        public void Create_Product_With_Negative_Value(string type, double price)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.productFactory.CreateProduct(type, price)).Message;

            Console.WriteLine(ex);
        }

        [Test]
        [TestCase("Gpu")]
        [TestCase("HardDrive")]
        [TestCase("Ram")]
        [TestCase("SolidStateDrive")]
        public void Create_Product_Correctly(string type)
        {
            var currentProduct = this.productFactory.CreateProduct(type, 5.25);
            var productType = currentProduct.GetType();

            Assert.IsInstanceOf(productType, currentProduct);
        }

    }
}
