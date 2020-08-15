using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using StorageMaster.Entities.Vehicles;
using StorageMaster.Entities.Storage;

namespace StorageMaster.Core.Tests
{
    public class EngineTests
    {
        private StorageMaster storegeMaster;


        [SetUp]
        public void LoadStorageManiger()
        {
            this.storegeMaster = new StorageMaster();

        }

        //Test Case Add Product 

        [Test]
        [TestCase("Gpu")]
        public void Test_Case_Add_Product_Return_Message(string productName)
        {
            var message = "Added {0} to pool";

            var returnMessage = this.storegeMaster.AddProduct(productName, 2.3);

            Assert.That(string.Format(message, productName), Is.EqualTo(returnMessage));
        }

        [Test]
        public void Test_Case_Add_Product_With_Valid_Parameters()
        {
            this.storegeMaster.AddProduct("Gpu", 2.3);
            this.storegeMaster.AddProduct("HardDrive", 1.3);
            this.storegeMaster.AddProduct("Ram", 3.1);

            var expectedCount = 3;

            var typeColection = ShowProductsPool().GetType();
            var productsPool = ShowProductsPool();

            var prop = typeColection.GetProperties().FirstOrDefault(x => x.Name == "Count");
            var count = prop.GetValue(productsPool);

            Assert.That(expectedCount, Is.EqualTo(count));

        }

        [Test]
        [TestCase("Gpu", -1)]
        public void Test_Case_Add_Product_With_Negative_Price(string productName, double price)
        {
            Assert.Throws<InvalidOperationException>(() => this.storegeMaster.AddProduct(productName, price));

        }

        [Test]
        [TestCase("Somthing", 2.3)]
        public void Test_Case_Add_Product_With_InValid_Type(string productName, double price)
        {
            Assert.Throws<InvalidOperationException>(() => this.storegeMaster.AddProduct(productName, price));
        }


        //Test Case Register storage

        [Test]
        [TestCase("AutomatedWarehouse", "Xpo")]
        public void Test_Case_Register_Store_Return_Message(string storageType, string storageName)
        {
            var message = "Registered {0}";
            var returnMessage = this.storegeMaster.RegisterStorage(storageType, storageName);

            Assert.That(string.Format(message, storageName), Is.EqualTo(returnMessage));
        }

        [Test]
        [TestCase("AutomatedWarehouse", "Xpo")]
        public void Test_Case_Register_Store_With_Valid_Parameters(string storageType, string storageName)
        {
            TestStorage();

            var expectedCount = 1;

            var typeColection = ShowStorageRegister().GetType();
            var storageRegister = ShowStorageRegister();

            var prop = typeColection.GetProperties().FirstOrDefault(x => x.Name == "Count");
            var count = prop.GetValue(storageRegister);

            Assert.That(expectedCount, Is.EqualTo(count));

        }

        [Test]
        [TestCase("AutomatedWarehouseE", "Xpo")]
        public void Test_Case_Register_Store_With_InValid_Storage_Type(string storageType, string storageName)
        {
            Assert.Throws<InvalidOperationException>(() => this.storegeMaster.RegisterStorage(storageType, storageName));

        }


        //Test Case Select Vehicle


        [Test]
        public void Test_Case_Select_Vehicle_Return_Message()
        {
            var message = "Selected {0}";

            TestStorage();
            var slot = 0;

            var returnMessage = storegeMaster.SelectVehicle("Xpo", slot);

            Assert.That(string.Format(message, "Truck"), Is.EqualTo(returnMessage));
        }

        [Test]
        public void Test_Case_Select_Vehicle_From_InValid_Slot()
        {
            TestStorage();
            var slot = 10;

            Assert.Throws<InvalidOperationException>(() => this.storegeMaster.SelectVehicle("Xpo", slot));
        }

        [Test]
        public void Test_Case_Select_Vehicle_From_Invalid_Store()
        {
            var slot = 0;
            Assert.Throws<KeyNotFoundException>(() => this.storegeMaster.SelectVehicle("Xpo", slot));
        }


        //Test Case Load Vehicle


        [Test]
        public void Test_Case_Load_Vehicle()
        {
            var expectedProductsCount = 3;

            this.storegeMaster.AddProduct("Gpu", 2.4);
            this.storegeMaster.AddProduct("HardDrive", 2.4);
            this.storegeMaster.AddProduct("SolidStateDrive", 2.4);

            TestStorage();
            this.storegeMaster.SelectVehicle("Xpo", 0);

            var products = new string[] { "Gpu", "HardDrive", "SolidStateDrive" };

            this.storegeMaster.LoadVehicle(products);
            var currentVehicle = ShowCurrentVehicle();

            Assert.That(expectedProductsCount, Is.EqualTo(currentVehicle.Trunk.Count));
        }

        [Test]
        public void Test_Case_Load_Vehicle_Return_Message()
        {
            var message = "Loaded 3/3 products into Truck";

            this.storegeMaster.AddProduct("Gpu", 2.4);
            this.storegeMaster.AddProduct("HardDrive", 2.4);
            this.storegeMaster.AddProduct("SolidStateDrive", 2.4);

            TestStorage();
            this.storegeMaster.SelectVehicle("Xpo", 0);

            var products = new string[] { "Gpu", "HardDrive", "SolidStateDrive" };

            var returnMessage = this.storegeMaster.LoadVehicle(products);

            Assert.That(message, Is.EqualTo(returnMessage));
        }

        [Test]
        public void Test_Case_Load_Vehicle_With_Full_Trunk()
        {
            for (int i = 0; i < 5; i++)
            {
                this.storegeMaster.AddProduct("HardDrive", 2.4);
            }

            TestStorage();
            this.storegeMaster.SelectVehicle("Xpo", 0);

            var products = new string[] { "HardDrive", "HardDrive", "HardDrive", "HardDrive", "HardDrive" };
            this.storegeMaster.LoadVehicle(products);

            var currentVehicle = ShowCurrentVehicle();

            Assert.IsTrue(currentVehicle.IsFull);

        }

        [Test]
        public void Test_Case_Load_Vehicle_With_Empty_Prducts_Pool()
        {
            TestStorage();
            this.storegeMaster.SelectVehicle("Xpo", 0);

            var products = new string[] { "Gpu", "HardDrive", "SolidStateDrive" };

            Assert.Throws<InvalidOperationException>(() => this.storegeMaster.LoadVehicle(products));
        }


        //Test Case Send Vehicle


        [Test]
        public void Test_Case_Send_Vehicle_To_Return_Message()
        {
            var message = "Sent Truck to DistributionCenter (slot 3)";

            TestStorage();
            this.storegeMaster.RegisterStorage("DistributionCenter", "DistributionCenter");

            string sourceName = "Xpo";
            int sourceGarageSlot = 0;

            string destinationName = "DistributionCenter";

            var returnMesage = this.storegeMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);

            Assert.That(message, Is.EqualTo(returnMesage));

        }

        [Test]
        public void Test_Case_Send_Vehicle_Check_Source_Storage_Garage_Count()
        {
            TestStorage();
            this.storegeMaster.RegisterStorage("DistributionCenter", "DistributionCenter");

            string sourceName = "Xpo";
            int sourceGarageSlot = 0;

            string destinationName = "DistributionCenter";

            this.storegeMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);

            var storageRegister = ShowStorageRegister();

            var storagees = storageRegister as Dictionary<string, Storage>;

            var sender = storagees["Xpo"];
            var firstSlotInGarage = sender.Garage.ToArray()[0];

            Assert.IsNull(firstSlotInGarage);

        }
        [Test]
        public void Test_Case_Send_Vehicle_Check_Destination_Storage_Garage_Count()
        {
            TestStorage();
            this.storegeMaster.RegisterStorage("DistributionCenter", "DistributionCenter");

            string sourceName = "Xpo";
            int sourceGarageSlot = 0;

            string destinationName = "DistributionCenter";

            var storageRegister = ShowStorageRegister();

            var storagees = storageRegister as Dictionary<string, Storage>;

            var garage = storagees["DistributionCenter"].Garage.ToArray();
            var firstEmptySlot = Array.IndexOf(garage, null);

            this.storegeMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
            var garageAfterSendVehicle = storagees["DistributionCenter"].Garage.ToArray();


            Assert.IsNotNull(garageAfterSendVehicle[firstEmptySlot]);


        }

        [Test]
        public void Test_Case_Send_Vehicle_With_InValid_Sender()
        {
            string sourceName = "Xpo";
            int sourceGarageSlot = 0;

            string destinationName = "DistributionCenter";

            var ex = Assert.Throws<InvalidOperationException>
                 (() => this.storegeMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName)).Message;

            Console.WriteLine(ex);
        }

        [Test]
        public void Test_Case_Send_Vehicle_With_InValid_Receiver()
        {
            TestStorage();

            string sourceName = "Xpo";
            int sourceGarageSlot = 0;

            string destinationName = "DistributionCenter";

            var ex = Assert.Throws<InvalidOperationException>
                 (() => this.storegeMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName)).Message;

            Console.WriteLine(ex);
        }


        //Test Case Unload Vehicle


        [Test]
        public void Test_Case_Unload_Vehicle_Return_Message()
        {
            var message = "Unloaded 2/2 products at Warehouse - XPO";

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");

            this.storegeMaster.AddProduct("HardDrive", 2.5);
            this.storegeMaster.AddProduct("HardDrive", 2.5);

            this.storegeMaster.SelectVehicle("Warehouse - XPO", 0);
            var products = new string[] { "HardDrive", "HardDrive" };

            this.storegeMaster.LoadVehicle(products);

            var returnMessage = this.storegeMaster.UnloadVehicle("Warehouse - XPO", 0);


            Assert.That(message, Is.EqualTo(returnMessage));

        }

        [Test]
        public void Test_Case_Unload_Vehicle_From_InValid_Storage()
        {
            Assert.Throws<KeyNotFoundException>(() => this.storegeMaster.UnloadVehicle("Warehouse - XPO", 0));

        }

        [Test]
        public void Test_Case_Unload_Vehicle_With_Empty_Trunk()
        {
            var message = "Unloaded 0/0 products at Warehouse - XPO";

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");

            this.storegeMaster.AddProduct("HardDrive", 2.5);
            this.storegeMaster.AddProduct("HardDrive", 2.5);


            var returnMessage = this.storegeMaster.UnloadVehicle("Warehouse - XPO", 0);


            Assert.That(message, Is.EqualTo(returnMessage));

        }

        [Test]
        public void Test_Case_Unload_Vehicle_With_InValid_Slot()
        {

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");

            this.storegeMaster.AddProduct("HardDrive", 2.5);
            this.storegeMaster.AddProduct("HardDrive", 2.5);

            Assert.Throws<InvalidOperationException>(() => this.storegeMaster.UnloadVehicle("Warehouse - XPO", 10));
        }


        //Test Case Get Storage Status


        [Test]
        public void Test_Case_Get_Storage_Status()
        {
            var message = "Stock ({0}/{1}): [{2}]";

            var unloadedProductsCount = 2;
            var productsCapacity = 10;
            var stockInfo = "HardDrive (2)";

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");

            this.storegeMaster.AddProduct("HardDrive", 2.5);
            this.storegeMaster.AddProduct("HardDrive", 2.5);

            this.storegeMaster.SelectVehicle("Warehouse - XPO", 0);
            var products = new string[] { "HardDrive", "HardDrive" };

            this.storegeMaster.LoadVehicle(products);

            this.storegeMaster.UnloadVehicle("Warehouse - XPO", 0);

            var returnMessage = this.storegeMaster.GetStorageStatus("Warehouse - XPO");
            var firstPartReturnMessage = returnMessage.Split(Environment.NewLine);


            Assert.That(string.Format(message, unloadedProductsCount, productsCapacity, stockInfo)
                , Is.EqualTo(firstPartReturnMessage[0]));

        }

        [Test]
        public void Test_Case_Get_Storage_Status_With_Not_Unloaded_Products()
        {
            var message = "Stock ({0}/{1}): [{2}]";

            var unloadedProductsCount = 0;
            var productsCapacity = 10;
            var stockInfo = "";

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");



            var returnMessage = this.storegeMaster.GetStorageStatus("Warehouse - XPO");
            var firstPartReturnMessage = returnMessage.Split(Environment.NewLine);


            Assert.That(string.Format(message, unloadedProductsCount, productsCapacity, stockInfo)
                , Is.EqualTo(firstPartReturnMessage[0]));

        }

        [Test]
        public void Test_Case_Get_Storage_Status_With_New_Vehicels_In_Garage()
        {
            var expectedEmptySlots = 6;

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");
            TestStorage();

            this.storegeMaster.SendVehicleTo("Xpo", 0, "Warehouse - XPO");

            var returnMessage = this.storegeMaster.GetStorageStatus("Warehouse - XPO");
            var secondPartReturnMesage = returnMessage.Split(Environment.NewLine);

            var emptySlotsCount = secondPartReturnMesage[1]
                .Split(new string[] { "|", "]" }
                , StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x == "empty").ToArray().Count();

            Assert.That(expectedEmptySlots, Is.EqualTo(emptySlotsCount));

        }



        //Test Case Get  Summary


        [Test]
        public void Test_Case_Get_Summary()
        {

            var message = "Storage worth: ${0}";
            var expectedMoney = "5,00";

            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");

            this.storegeMaster.AddProduct("HardDrive", 2.5);
            this.storegeMaster.AddProduct("HardDrive", 2.5);

            this.storegeMaster.SelectVehicle("Warehouse - XPO", 0);
            var products = new string[] { "HardDrive", "HardDrive" };

            this.storegeMaster.LoadVehicle(products);

            this.storegeMaster.UnloadVehicle("Warehouse - XPO", 0);


            var mess = this.storegeMaster.GetSummary();
            var moneyInfo = mess.Split(Environment.NewLine);

            Assert.That(string.Format(message, expectedMoney), Is.EqualTo(moneyInfo[1]));
        }
        [Test]
        public void Test_Case_Get_Summary_More_Than_One()
        {
            var messageFirstStor = "Storage worth: $5,00";
            var messageSecondStore = "Storage worth: $0,00";

            this.storegeMaster.RegisterStorage("AutomatedWarehouse", "AutomatedWarehouse - XPO");


            this.storegeMaster.RegisterStorage("Warehouse", "Warehouse - XPO");

            this.storegeMaster.AddProduct("HardDrive", 2.5);
            this.storegeMaster.AddProduct("HardDrive", 2.5);

            this.storegeMaster.SelectVehicle("Warehouse - XPO", 0);
            var products = new string[] { "HardDrive", "HardDrive" };

            this.storegeMaster.LoadVehicle(products);

            this.storegeMaster.UnloadVehicle("Warehouse - XPO", 0);

            var returnMessages = this.storegeMaster.GetSummary().Split(Environment.NewLine);

            var firstStore = returnMessages[1].Split(Environment.NewLine);
            var secondStore = returnMessages[3].Split(Environment.NewLine);


            Assert.That(messageFirstStor, Is.EqualTo(firstStore[0]));
            Assert.That(messageSecondStore, Is.EqualTo(secondStore[0]));
        }

        private Object ShowProductsPool()
        {
            return typeof(StorageMaster)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "productsPool")
                .GetValue(this.storegeMaster);
        }

        private Object ShowStorageRegister()
        {
            return typeof(StorageMaster)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "storageRegistry").GetValue(this.storegeMaster);
        }

        private void TestStorage()
        {
            var registerStorage = this.storegeMaster.RegisterStorage("AutomatedWarehouse", "Xpo");
        }

        private Vehicle ShowCurrentVehicle()
        {
            var currentVehicle = typeof(StorageMaster)
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .FirstOrDefault(x => x.Name == "currentVehicle").GetValue(this.storegeMaster);

            return (Truck)currentVehicle;
        }





    }
}
