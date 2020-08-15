namespace StorageMaster.Tests
{
    using System;

    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    public class ProductRamTests
    {


        private Product product;

        [Test]
        public void Correctly_Set_Of_Product_Price()
        {
            this.product = new Ram(3.5);
            var exceptedProductPrice = 3.5;

            Assert.That(exceptedProductPrice, Is.EqualTo(this.product.Price));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-20)]
        public void Test_Product_Price_With_Negative_Value(double price)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.product = new Ram(price)).Message;
            Console.WriteLine(ex);
        }

        [Test]
        public void Test_Produt_Price_In_Range()
        {
            // Range from 0 to 25
            for (int price = 0; price <= 25; price++)
            {
                this.product = new Ram(price);
            }
        }

        [Test]
        public void Correctly_Set_Of_Product_Weight()
        {
            this.product = new Ram(3.5);
            var defouthWeight = product.Weight;

            Assert.That(defouthWeight, Is.EqualTo(this.product.Weight));
        }

        [Test]
        public void Correctly_Instance_Product_Name()
        {
            this.product = new Ram(5);
            var exceptedProductName = "Ram";

            Assert.That(exceptedProductName, Is.EqualTo(product.GetType().Name));
        }
    }
}
