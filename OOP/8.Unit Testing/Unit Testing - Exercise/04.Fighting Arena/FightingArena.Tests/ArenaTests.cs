namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior attacker;
        private Warrior defender;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            attacker = new("Silas", 50, 100);
            defender = new("Slabas", 20, 100);
        }

        [Test]
        public void Ctor_ShouldInitializeCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void Count_ShouldInitializeCorrectly()
        {
            arena = new();
            arena.Enroll(attacker);
            int expectedResult = 1;
            Assert.AreEqual(expectedResult,arena.Count);
        }

        [Test]
        public void Enroll_ShouldThrowException_WhenWarriorAlreadyEnrolled()
        {
            arena.Enroll(attacker);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(attacker));
        }

        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            arena.Enroll(attacker);
            arena.Enroll(defender);
            int defenderExpectedHealth = 50;
            int attackerExpectedHealth = 80;
            arena.Fight(attacker.Name,defender.Name);
            Assert.AreEqual(defenderExpectedHealth,defender.HP);
            Assert.AreEqual(attackerExpectedHealth, attacker.HP);
        }

        [Test]
        public void Arena_FightShouldThrowExceptionIfAttackerNotFound()
        {

            arena.Enroll(defender);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void Arena_FightShouldThrowExceptionIfDefenderNotFound()
        {
            
            arena.Enroll(attacker);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));
            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }
    }
}
