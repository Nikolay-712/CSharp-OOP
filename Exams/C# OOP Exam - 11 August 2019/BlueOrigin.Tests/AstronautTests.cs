using NUnit.Framework;


namespace BlueOrigin.Tests
{
    public class AstronautTests
    {
        [Test]
        public void Correctly_Set_Parameters()
        {
            Astronaut astronaut = new Astronaut("Kole",10.35);

            var expectedName = "Kole";
            var expectedOxygenInPercentage = 10.35;

            Assert.That(expectedName, Is.EqualTo(astronaut.Name));
            Assert.That(expectedOxygenInPercentage, Is.EqualTo(astronaut.OxygenInPercentage));
        }

    }
}
