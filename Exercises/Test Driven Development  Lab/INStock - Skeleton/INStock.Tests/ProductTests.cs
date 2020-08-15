namespace INStock.Tests
{
    using NUnit.Framework;
    using System;

    public class ProductTests
    {
        [Test]
        [TestCase("Food", "Mozzarella", 5.65, 4)]
        public void Correctly_Set_Product_Info(string type, string label, decimal price, int quantity)
        {
            var product = new Product(type, label, price, quantity);

            Assert.That("Mozzarella", Is.EqualTo(product.Label));
            Assert.That(5.65, Is.EqualTo(product.Price));
            Assert.That(4, Is.EqualTo(product.Quantity));
        }

        [Test]
        [TestCase("Food", " ", 5.65, 4)]
        public void Test_Case_Set_Product_Label_Info_With_Not_Valid_Text
            (string type, string invalidLabel, decimal price, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(type, invalidLabel, price, quantity));
        }

        [Test]
        [TestCase("Food", "Mozzarella", -1, 4)]
        [TestCase("Food", "Mozzarella", 51, 4)]
        public void Test_Case_Set_Product_Price_With_Not_Valid_Range
            (string type, string label, decimal invalidPrice, int quantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(type,label,invalidPrice,quantity));
        }

        [Test]
        [TestCase("Food", "Mozzarella", 2.51, -4)]
        public void Test_Case_Set_Product_Quantity_With_Negative_Value
           (string type, string label, decimal price, int negativeQuantity)
        {
            Assert.Throws<ArgumentException>(() => new Product(type, label, price, negativeQuantity));
        }

    }
}