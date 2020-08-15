using NUnit.Framework;
using StorageMaster.Entities.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Tests
{
    public class StorageFactoryTests
    {
        private StorageFactory storageFactory;

        [SetUp]
        public void TestFactory()
        {
            this.storageFactory = new StorageFactory();
        }

        [Test]
        [TestCase("SuperAutomatedWarehouse", "XPO")]
        [TestCase("DistributionCenterFactory", "Fabric")]
        [TestCase("Warehouse234", "Logistik")]
       
        public void Create_Storage_With_Invalid_Type(string type, string name)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.storageFactory.CreateStorage(type, name)).Message;

            Console.WriteLine(ex);
        }

        [Test]
        [TestCase("AutomatedWarehouse", "XPO")]
      
        public void Create_Storage_Successfully(string type, string name)
        {
            var store = this.storageFactory.CreateStorage(type, name);

            Assert.That("AutomatedWarehouse", Is.EqualTo(store.GetType().Name));
        }
    }
}
