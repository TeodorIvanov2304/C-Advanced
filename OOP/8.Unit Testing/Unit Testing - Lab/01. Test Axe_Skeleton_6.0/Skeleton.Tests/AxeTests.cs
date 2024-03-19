using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(3, 2);
            dummy = new Dummy(5, 2);
        }

        [Test]
        //Тестваме, дали се зарежда правилно брадвата
        public void NewAxe_ShouldSetDataCorrectly()
        {
            Assert.AreEqual(axe.AttackPoints, 3);
            Assert.AreEqual(axe.DurabilityPoints, 2);
        }

        //Тестваме, дали на брадвата й пада издръжливостта, след като удари
        [Test]
        public void Attack_ShouldDecreaseDurability()
        {
            axe.Attack(dummy);
            Assert.AreEqual(axe.DurabilityPoints,1);
        }

        [Test]
        //Тестваме, дали ако ударим със строшено оръжие, ще хвърли грешка
        public void AttackWithBrokenWeapon_ShouldThrowError()
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            //Throws очаква делегат! Всички методи, оградени с <> очакват делегат. Много важен синтаксис!
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });

        }

        [Test]
        //Тестваме, дали оръжието не е с негативна здравина
        public void Attack_WithNegativeDurability()
        {
            Axe axe = new(5, -50);
            
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });

        }
    }
}