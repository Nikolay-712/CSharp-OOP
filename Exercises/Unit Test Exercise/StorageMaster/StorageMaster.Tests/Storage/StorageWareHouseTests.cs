namespace StorageMaster.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    public class StorageWareHouseTests
    {
        private Storage storage;

        [SetUp]
        public void CreateStorage()
        {
            this.storage = new Warehouse("XPO");
        }

        [Test]
        public void Correctly_Set_Of_Store_Name()
        {
            var exceptedStoreName = "XPO";
            var currentStoreName = this.storage.Name;

            Assert.That(exceptedStoreName, Is.EqualTo(currentStoreName));
        }

        [Test]
        public void Correctly_Set_Of_Store_Capacity()
        {
            var exceptedStoreCapacity = 10;
            var currentStoreCapacity = this.storage.Capacity;

            Assert.That(exceptedStoreCapacity, Is.EqualTo(currentStoreCapacity));
        }
        [Test]
        public void Correctly_Set_Of_Store_GarageSlots()
        {
            var exceptedStoreGarageSlots = 10;
            var currentStoreGarageSlots = this.storage.GarageSlots;

            Assert.That(exceptedStoreGarageSlots, Is.EqualTo(currentStoreGarageSlots));
        }

        [Test]
        public void Correctly_Create_Garage_With_GarageSlots_Count()
        {
            var exceptedGarageSlots = 10;
            var garageSlots = this.storage.Garage.Count;

            Assert.That(exceptedGarageSlots, Is.EqualTo(garageSlots));

            foreach (var item in this.storage.Garage.Skip(3))
            {
                Assert.IsNull(item);
            }

        }

        [Test]
        public void Correctly_Set_Of_Default_Vehicles_In_Garage()
        {
            var defaultVehiclesInGarage = 3;
            var defaultTypeVehiclesInGarage = "Semi";

            var defaultVehicles = this.storage.Garage.Take(defaultVehiclesInGarage);

            Assert.That(defaultVehiclesInGarage, Is.EqualTo(defaultVehicles.Count()));

            foreach (var item in defaultVehicles)
            {
                Assert.That(defaultTypeVehiclesInGarage, Is.EqualTo(item.GetType().Name));
                Assert.IsNotNull(item);
            }
        }

        [Test]
        public void Correctly_Create_Of_Products_List()
        {
            var exceptedProductsCount = 0;
            var productListCount = this.storage.Products.Count;

            Assert.That(exceptedProductsCount, Is.EqualTo(productListCount));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Check_For_Successful_Implementation_Of_Method_GetVehicle(int garageSlot)
        {
            var vehicle = this.storage.GetVehicle(garageSlot);

            Assert.That(vehicle, Is.EqualTo(this.storage.Garage.ToArray()[garageSlot]));

        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(25)]
        public void Check_For_Successful_Implementation_Of_Method_GetVehicle_With_Out_Range_Parameters(int garageSlot)
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.storage.GetVehicle(garageSlot)).Message;
            Console.WriteLine(ex);
        }
        [Test]
        public void Check_For_Successful_Implementation_Of_Method_GetVehicle_With_Empty_Slot()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.storage.GetVehicle(3)).Message;
            Console.WriteLine(ex);
        }
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Check_For_Successful_Implementation_Of_Method_SendVehicleTo(int slot)
        {
            var targetStorage = new DistributionCenter("DistributionCenter");

            this.storage.SendVehicleTo(slot, targetStorage);

            Assert.IsNull(this.storage.Garage.ToList()[slot]);
        }
        [Test]
        public void Successful_Implementation_AcceptsVicle_In_Storage()
        {
            var targetStorage = new DistributionCenter("DistributionCenter");
            var garage = targetStorage.Garage.ToArray();

            for (int slot = 0; slot <= 1; slot++)
            {
                var firstEmptySlot = Array.IndexOf(garage, null);
                garage[firstEmptySlot] = new Truck();

                Assert.IsNotNull(garage[firstEmptySlot]);
            }
        }

        [Test]
        public void In_Full_Garage_Add_New_Vehicle()
        {
            var targetStorage = new DistributionCenter("DistributionCenter");
            var garage = targetStorage.Garage.ToArray();

            for (int slot = 0; slot <= 1; slot++)
            {
                var firstEmptySlot = Array.IndexOf(garage, null);
                garage[firstEmptySlot] = new Truck();
            }

            var deliveryGarageHasFreeSlot = garage.Any(v => v == null);

            Assert.IsFalse(deliveryGarageHasFreeSlot);
        }

        [Test]
        public void Successful_Implementation_Method_UnloadVehicle()
        {
            int slot = 0;
            var currentVehicle = this.storage.GetVehicle(slot);

            var expectedUnloadedProductCount = 3;
            var unloadedProductCount = 0;

            var product = new Gpu(2);

            for (int i = 0; i <= 2; i++)
            {
                currentVehicle.LoadProduct(product);
            }

            this.storage.UnloadVehicle(0);
            unloadedProductCount = this.storage.Products.Count();

            Assert.That(expectedUnloadedProductCount, Is.EqualTo(unloadedProductCount));
        }

        [Test]
        public void Implementation_Method_UnloadVehicle_In_Full_Store()
        {
            int slot = 0;

            var currentVehicle = this.storage.GetVehicle(slot);
            var currentVehicle1 = this.storage.GetVehicle(1);

            var product = new HardDrive(2);
            currentVehicle1.LoadProduct(product);

            for (int i = 0; i < 10; i++)
            {
                currentVehicle.LoadProduct(product);
            }
            this.storage.UnloadVehicle(0);

            var ex = Assert.Throws<InvalidOperationException>(() => this.storage.UnloadVehicle(1)).Message;
            Console.WriteLine(ex);
        }

        [Test]
        public void Successful_Implementation_Method_InitializeGarage()
        {
            var expectedCountVihecles = 3;

            var defaultGarage = this.storage.Garage.Take(expectedCountVihecles);

            foreach (var item in defaultGarage)
            {
                Assert.IsNotNull(item);
            }

            var defaultEmptySlots = this.storage.Garage.Skip(expectedCountVihecles);

            foreach (var item in defaultEmptySlots)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void Successful_Implementation_Method_AddVehicle()
        {
            MethodInfo[] methodInfo = typeof(Storage)
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var expectedCountVihecles = 4;

            var addVehicle = methodInfo[1].Invoke(this.storage, new object[] { new Truck() });

            Assert.That(expectedCountVihecles, Is.EqualTo(this.storage.Garage.Where(x => x != null).Count()));
        }
    }
}
