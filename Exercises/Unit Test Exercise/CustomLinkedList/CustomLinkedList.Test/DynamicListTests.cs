using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLinkedList.Test
{
    public class DynamicListTests
    {
        private DynamicList<int> dinamicList;

        [SetUp]
        public void TestInit()
        {
            this.dinamicList = new DynamicList<int>();

            var defaultElementsCount = 5;

            for (int element = 1; element <= defaultElementsCount; element++)
            {
                this.dinamicList.Add(element);
            }
        }

        [Test]
        public void Test_Case_Add_Element_Correctly_In_Colection()
        {
            var expectedCount = 5;

            Assert.That(expectedCount, Is.EqualTo(this.dinamicList.Count));
        }

        [Test]
        public void Test_Case_RemoveAt_Element_Of_Correct_Index()
        {
            var removedElement = 2;
            var expectedCount = 4;

            this.dinamicList.RemoveAt(1);

            Assert.IsFalse(this.dinamicList.Contains(removedElement));
            Assert.That(expectedCount, Is.EqualTo(this.dinamicList.Count));
        }

        [Test]
        public void Test_Case_RemoveAt_Element_Out_Of_Range()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dinamicList.RemoveAt(15));
        }

        [Test]
        public void Test_Case_RemoveAt_Element_With_Negative_Index()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dinamicList.RemoveAt(-5));
        }

        [Test]
        public void Test_Case_Remove_Element()
        {
            int positionOfRemoveedElement = 2;

            int elementIndex = this.dinamicList.Remove(3);

            Assert.That(positionOfRemoveedElement, Is.EqualTo(elementIndex));
        }

        [Test]
        public void Test_Case_Remove_Element_Who_Not_Existing_In_Colection()
        {
            int positionOfRemoveedElement = -1;
            int expectedCount = 5;

            int elementIndex = this.dinamicList.Remove(31);

            Assert.That(positionOfRemoveedElement, Is.EqualTo(elementIndex));
            Assert.That(expectedCount, Is.EqualTo(this.dinamicList.Count));
        }

        [Test]
        public void Test_Case_Index_Of()
        {
            int expectedIndex = 2;

            Assert.That(expectedIndex, Is.EqualTo(this.dinamicList.IndexOf(3)));
        }

        [Test]
        public void Test_Case_Index_Of_Who_Not_Existing_In_Colection()
        {
            int expectedIndex = -1;

            Assert.That(expectedIndex, Is.EqualTo(this.dinamicList.IndexOf(15)));
        }

        [Test]
        public void Test_Case_Contains_Element()
        {
            Assert.IsTrue(this.dinamicList.Contains(2));
        }
        [Test]
        public void Test_Case_Contains_Element_Does_Not_Exists()
        {
            Assert.IsFalse(this.dinamicList.Contains(12));
        }
    }
}
