using FluentAssertions;
using NUnit.Framework;
using System;

namespace Skeleton.Test
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void Dummy_Loses_Health_If_Attacked()
        {
            Dummy dummy = new Dummy(5, 10);
            dummy.TakeAttack(2);

            dummy.Health.Should().Be(3);
            Assert.That(dummy.Health, Is.EqualTo(3), "Health doesn't change after atack");
        }
        [Test]
        public void Dead_Dummy_Throws_Exception_If_Attacked()
        {
            Dummy dummy = new Dummy(5, 10);
            dummy.TakeAttack(5);

            var ex = Assert.Throws<InvalidOperationException>
                     (() => dummy.TakeAttack(6));


            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));

        }
        [Test]
        public void Dead_Dummy_Can_Give_Experience()
        {
            Dummy dummy = new Dummy(0,10);
            dummy.GiveExperience();

            Assert.That(10, Is.EqualTo(dummy.GiveExperience()));
        }
        [Test]
        public void Alive_Dummy_Cannot_Give_Experience()
        {
            Dummy dummy = new Dummy(5, 10);


            var ex = Assert.Throws<InvalidOperationException>
                     (() => dummy.GiveExperience());

            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }

    }
}
