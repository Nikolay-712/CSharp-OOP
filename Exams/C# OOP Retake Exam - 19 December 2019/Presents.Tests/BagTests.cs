namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    public class BagTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
        }

        [Test]
        public void Correctly_Initialized_Bag_Collection_Check_The_Count()
        {
            var expectedCount = 0;

            Assert.That(expectedCount, Is.EqualTo(this.bag.GetPresents().Count));
        }

        [Test]
        public void Test_Case_Createe_Present_With_Invalid_Type_Present()
        {
            Assert.Throws<ArgumentNullException>(() => this.bag.Create(null));
        }

        [Test]
        public void Test_Case_Createe_Present_With_Already_Exists_Present()
        {
            var present = new Present("TestName", 2.5);

            this.bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => this.bag.Create(present));
        }

        [Test]
        public void Test_Case_Create_Present_Seccesfully_Return_Message()
        {
            var present = new Present("TestName", 2.5);

            var message = this.bag.Create(present);

            var expectedMessage = "Successfully added present TestName.";

            Assert.That(expectedMessage, Is.EqualTo(message));
        }

        [Test]
        public void Test_Case_Removee_Present_Seccesfully()
        {
            var present = new Present("TestName", 2.5);

            var message = this.bag.Create(present);

            Assert.IsTrue(this.bag.Remove(present));
        }

        [Test]
        public void Test_Case_Removee_Present_Which_Does_Not_Exist()
        {
            var present = new Present("TestName", 2.5);

            Assert.IsFalse(this.bag.Remove(present));

        }

        [Test]
        public void Test_Case_Removee_Present_And_Decrease_Collection_Count()
        {
            var present = new Present("TestName", 2.5);
            var present1 = new Present("TestName1", 2.5);

            this.bag.Create(present);
            this.bag.Create(present1);

            this.bag.Remove(present1);

            var expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.bag.GetPresents().Count));

        }

        [Test]
        public void Test_Case_Get_Present_With_Least_Magic()
        {
            var present = new Present("TestName", 2.5);
            var present1 = new Present("TestName1", 12.5);
            var present2 = new Present("TestName2", 22.5);
            var present3 = new Present("TestName3", 0.5);

            this.bag.Create(present);
            this.bag.Create(present1);
            this.bag.Create(present2);
            this.bag.Create(present3);

            var expectedPresent = present3;

            Assert.That(expectedPresent, Is.EqualTo(this.bag.GetPresentWithLeastMagic()));

        }

        [Test]
        public void Test_Case_Get_Present_With_Least_Magic_From_Empty_Bag()
        {

            Assert.Throws<InvalidOperationException>(() => this.bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void Test_Case_Get_Present_With_Name_Seccesfully()
        {
            var present = new Present("TestName", 2.5);
            var present1 = new Present("TestName1", 12.5);

            this.bag.Create(present);
            this.bag.Create(present1);

            var expectedPresent = present1;

            Assert.That(expectedPresent, Is.EqualTo(this.bag.GetPresent("TestName1")));
        }

    }
}
