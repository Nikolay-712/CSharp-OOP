namespace INStock.Tests
{
    using INStock.Contracts;

    using NUnit.Framework;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using System;

    public class ProductStockTests
    {
        private ProductStock productStock;
        Dictionary<string, List<IProduct>> products;

        [SetUp]
        public void LoadProductStock()
        {
            this.productStock = new ProductStock();

            this.products = typeof(ProductStock)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "Products")
                .GetValue(this.productStock)
                as Dictionary<string, List<IProduct>>;
        }


        // Test Case Add New Product

        [Test]
        public void Test_Case_Add_New_Product_Successfully()
        {
            var expectedCount = 2;

            IProduct product1 = new Product("Hardware", "HDD", 25.5m, 4);
            IProduct product2 = new Product("Hardware", "GPU", 45.5m, 4);

            this.productStock.Add(product1);
            this.productStock.Add(product2);

            Assert.That(expectedCount, Is.EqualTo(this.productStock.Count));
        }

        [Test]
        public void Test_Case_Add_New_Product_With_Same_Label_And_Update_Quantity_Successfully()
        {
            var expectedQuantity = 6;

            IProduct product1 = new Product("Hardware", "HDD", 25.5m, 4);
            IProduct product2 = new Product("Hardware", "HDD", 12.3m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);

            var productQuantity = products["Hardware"].First().Quantity;

            Assert.That(expectedQuantity, Is.EqualTo(productQuantity));
        }

        [Test]
        public void Test_Case_Add_New_Product_With_Same_Label_And_Update_Price_Successfully()
        {
            var expectedPrice = 22.3m;

            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product2 = new Product("Hardware", "HDD", 22.3m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);

            var productQuantity = products["Hardware"].First().Price;

            Assert.That(expectedPrice, Is.EqualTo(productQuantity));
        }


        //Test Case Contains Product

        [Test]
        public void Test_Case_Contains_Product()
        {
            IProduct product1 = new Product("Hardware", "HDD", 25.5m, 4);
            IProduct product2 = new Product("Hardware", "HDD", 12.3m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);

            var containsProduct = this.productStock.Contains(product2);

            Assert.IsTrue(containsProduct);
        }


        // Test Case Finde Product 


        [Test]
        public void Test_Case_Finde_Product_Successfully()
        {

            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "HDD", 5.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 30.00m, 5);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            var expectedProductType = product5.ProductType;
            var expectedProductLabel = product5.Label;

            var targetProduct = this.productStock.Find("Hardware", 0);

            var targetProductType = targetProduct.ProductType;
            var targetProductLabel = targetProduct.Label;

            Assert.That(expectedProductType, Is.EqualTo(targetProductType));
            Assert.That(expectedProductLabel, Is.EqualTo(targetProduct.Label));


        }

        [Test]
        public void Test_Case_Finde_Product_With_InValid_Type()
        {

            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 30.00m, 5);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);

            Assert.Throws<ArgumentException>(() => this.productStock.Find("Food", 1));
        }

        [Test]
        public void Test_Case_Finde_Product_With_InValid_Index()
        {

            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 30.00m, 5);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);

            Assert.Throws<ArgumentException>(() => this.productStock.Find("Speakers", 3));
        }


        // Test Case Finde Product By Price


        [Test]
        public void Test_Case_Find_All_Products_By_Price_Successfully()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 15.50m, 5);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            var productsWitPrice = this.productStock.FindAllByPrice(15.50m);
            var expectedCount = 3;

            Assert.That(expectedCount, Is.EqualTo(productsWitPrice.Count()));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(54)]
        public void Test_Case_Find_All_Products_By_Invalid_Price(decimal price)
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 15.50m, 5);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            Assert.Throws<ArgumentException>(() => this.productStock.FindAllByPrice(price));



        }

        [Test]
        public void Test_Case_Finde_All_Products_By_Price_With_Empty_Products_List()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindAllByPrice(5));
        }


        // Test Case Finde Product By Quantity


        [Test]
        public void Test_Case_Find_All_Products_By_Quantity_Successfully()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 15.50m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            var productsWitquantity = this.productStock.FindAllByQuantity(2);
            var expectedCount = 3;

            Assert.That(expectedCount, Is.EqualTo(productsWitquantity.Count()));
        }

        [Test]
        public void Test_Case_Finde_All_Products_By_Quantity_With_Empty_Products_List()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindAllByQuantity(7));
        }

        [Test]
        public void Test_Case_Finde_All_Products_By_Quantity_With_Negative_Quantity()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 15.50m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            Assert.Throws<ArgumentException>(() => this.productStock.FindAllByQuantity(-1));
        }


        // Test Case Finde Product By Label

        [Test]
        public void Test_Case_Find_All_Products_By_Label_Successfully()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 15.50m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            var expectedProductType = "Speakers";
            var expectedProductLabel = "Sony";

            var targetProduct = this.productStock.FindByLabel("Sony");

            var targetProductType = targetProduct.ProductType;
            var targetProductLabel = targetProduct.Label;

            Assert.That(expectedProductType, Is.EqualTo(targetProductType));
            Assert.That(expectedProductLabel, Is.EqualTo(targetProductLabel));
        }

        [Test]
        public void Test_Case_Find_All_Products_By_Label_With_InValid_Label()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product5 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product2 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product4 = new Product("Speakers", "Philips", 15.50m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);

            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel(" "));
        }

        [Test]
        public void Test_Case_Find_All_Products_By_Label_With_Not_Found()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product2 = new Product("Hardware", "SSD", 15.5m, 2);

            this.productStock.Add(product1);
            this.productStock.Add(product2);


            Assert.Throws<ArgumentException>(() => this.productStock.FindByLabel("Speakers"));
        }


        // Test Case Finde Most Expensive Product

        [Test]
        public void Test_Case_Find_Most_Expensive_Product()
        {
            IProduct product1 = new Product("Hardware", "HDD", 15.5m, 4);
            IProduct product2 = new Product("Hardware", "SSD", 15.5m, 2);
            IProduct product3 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product6 = new Product("Speakers", "Philips", 45.50m, 2);
            IProduct product4 = new Product("Speakers", "Sony", 20.00m, 10);
            IProduct product5 = new Product("Speakers", "Philips", 15.50m, 2);


            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);
            this.productStock.Add(product4);
            this.productStock.Add(product5);
            this.productStock.Add(product6);

            var expectedMostBigPrice = 45.5m;

            var mostExpensiveProduct = this.productStock.FindMostExpensiveProduct();

            Assert.That(expectedMostBigPrice, Is.EqualTo(mostExpensiveProduct.Price));
        }

        [Test]
        public void Test_Case_Finde_Most_Expensive_Product_With_Empty_Products_List()
        {
            Assert.Throws<ArgumentException>(() => this.productStock.FindMostExpensiveProduct());
        }

        // Test Case Remove Product


        [Test]
        public void Test_Case_Remove_Product_Successfully()
        {
            IProduct product1 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product2 = new Product("Speakers", "Philips", 45.50m, 2);
            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            Assert.IsTrue(this.productStock.Remove(product1));
        }

        [Test]
        public void Test_Case_Remove_Product_With_Only_One_Product_From_Type()
        {
            IProduct product1 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product2 = new Product("Speakers", "Philips", 45.50m, 2);
            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

           this.productStock.Remove(product1);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.products.Count));
        }

        [Test]
        public void Test_Case_Remove_Product_With_More_Than_One_Product_From_Type()
        {
            IProduct product1 = new Product("Hardware", "GPU", 22.3m, 2);

            IProduct product2 = new Product("Speakers", "Philips", 45.50m, 2);
            IProduct product3 = new Product("Speakers", "Sony", 20.00m, 10);

            this.productStock.Add(product1);
            this.productStock.Add(product2);
            this.productStock.Add(product3);

            this.productStock.Remove(product2);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.products[product2.ProductType].Count));


        }
    }
}
