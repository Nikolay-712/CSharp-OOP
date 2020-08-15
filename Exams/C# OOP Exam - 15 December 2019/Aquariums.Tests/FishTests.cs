using NUnit.Framework;

namespace Aquariums.Tests
{
    public class FishTests
    {
        [Test]
        public void Correctly_Set_Of_Fish_Parameters()
        {

            Fish fish = new Fish("Riba");

            var expectedName = "Riba";
            var isAvailable = true;

            Assert.That(expectedName,Is.EqualTo(fish.Name));
            Assert.IsTrue(isAvailable);
        }

    }
}
