namespace Presents.Tests
{
    using NUnit.Framework;

    public class PresentsTests
    {
        [Test]
        public void Correctly_Set_Of_Parameters()
        {
            Present present = new Present("TestName", 2.5);

            var expectedName = "TestName";
            var expectedMagicValue = 2.5;

            Assert.That(expectedName, Is.EqualTo(present.Name));
            Assert.That(expectedMagicValue, Is.EqualTo(present.Magic));
        }
    }
}
