using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Test
{
    [TestFixture]
    public class HeroTestes
    {
        [Test]
        public void Hero_Gains_Experience_After_Attack_Death_Target()
        {
            Hero hero = new Hero("Heroo");
            ITarget target = new Dummy(5, 5);

            hero.Attack(target);

            Assert.That(5, Is.EqualTo(hero.Experience));
        }
        [Test]
        public void Hero_Gain_Experince_When_Kill_ATarget()
        {
            // Arrange
            Mock<ITarget> fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(t => t.Health).Returns(0);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(5);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero("Edin Tam Geroi");

            var tova = fakeTarget.Object;

            // Act
            hero.Attack(fakeTarget.Object);

            // Assert
           // Assert.AreEqual(5, hero.Experience);
            hero.Experience.Should().Be(5);
        }
    }
}
