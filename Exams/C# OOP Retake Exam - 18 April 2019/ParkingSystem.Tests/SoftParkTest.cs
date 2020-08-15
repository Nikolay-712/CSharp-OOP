namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;

    public class SoftParkTest
    {
        private SoftPark softPark;

        [SetUp]
        public void Setup()
        {
            this.softPark = new SoftPark();
        }

        [Test]
        public void Correctly_Set_Empty_Parking_Slots()
        {
            var expectedEmptySlotsCount = 12;

            Assert.That(expectedEmptySlotsCount, Is.EqualTo(this.softPark.Parking.Count));

            foreach (var item in this.softPark.Parking.Values)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void Park_Car_Successfully_On_Empty_Slot()
        {
            Car car = new Car("Honda","PK0000AP");

            this.softPark.ParkCar("B1",car);

            Assert.IsNotNull(this.softPark.Parking["B1"]);
        }

        [Test]
        public void Park_Car_Successfully_Test_Return_Message()
        {
            Car car = new Car("Honda", "PK0000AP");

            var expectedMessage = "Car:PK0000AP parked successfully!";

            Assert.That(expectedMessage, Is.EqualTo(this.softPark.ParkCar("B1", car)));
        }

        [Test]
        public void Park_Car_which_Exists()
        {
            Car car = new Car("Honda", "PK0000AP");
            this.softPark.ParkCar("B1", car);

            Assert.Throws<InvalidOperationException>(() => this.softPark.ParkCar("A1", new Car("Honda", "PK0000AP")));
        }

        [Test]
        public void Park_Car_Of_Parking_Spot_Is_Already_Taken()
        {
            Car car = new Car("Honda", "PK0000AP");
            this.softPark.ParkCar("B1", car);

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("B1", new Car("Porshe", "CC3434AB")));
        }

        [Test]
        public void Park_Car_Of_Parking_Spot_Doesnt_Exists()
        {

            Assert.Throws<ArgumentException>(() => this.softPark.ParkCar("R4", new Car("Fiat", "AA5000AC")));
        }

        [Test]
        public void Remove_Car_Successfully_Test_Return_Message()
        {
            Car car = new Car("Honda", "PK0000AP");
            Car car1 = new Car("Fiat", "AA5000AC");

            this.softPark.ParkCar("B1", car);
            this.softPark.ParkCar("A1", car1);

            var expectedMessage = "Remove car:AA5000AC successfully!";

            Assert.That(expectedMessage, Is.EqualTo(this.softPark.RemoveCar("A1",car1)));

        }

        [Test]
        public void Remove_Car_Successfully_And_Check_Current_Slot()
        {

            Car car = new Car("Honda", "PK0000AP");
            Car car1 = new Car("Fiat", "AA5000AC");

            this.softPark.ParkCar("B1", car);
            this.softPark.ParkCar("A1", car1);

            this.softPark.RemoveCar("A1", car1);

            Assert.IsNull(this.softPark.Parking["A1"]);
        }

        [Test]
        public void Remove_Car_From_Exsist_Slot_Different_Car()
        {
            Car car = new Car("Honda", "PK0000AP");
            Car car1 = new Car("Fiat", "AA5000AC");

            this.softPark.ParkCar("B1", car);
            this.softPark.ParkCar("A1", car1);

            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("B1", car1));

        }

        [Test]
        public void Remove_Car_From_Invalid_Slot()
        {
            Assert.Throws<ArgumentException>(() => this.softPark.RemoveCar("A10", new Car("Porshe", "B1212AA")));
        }
    }
}