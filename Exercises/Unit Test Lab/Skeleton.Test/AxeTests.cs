using NUnit.Framework;
using FluentAssertions;
using System;

namespace Skeleton.Test
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Axe_Loses_Durability_After_Attack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(5, 10);

            axe.Attack(dummy);

            axe.DurabilityPoints.Should().Be(9);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Durability doesn't change after atack");

        }
        [Test]
        public void Attacking_With_Broken_Weapon()
        {
            Axe axe = new Axe(10, 0);

            var message = Assert.Throws<InvalidOperationException>
                     (() => axe.Attack(new Dummy(5,10))).Message;

            Console.WriteLine(message);
        }


    }
}
