using System;
using NUnit.Framework.Internal;

namespace FightingArena.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class WarriorTests
    {   
        
        private const string CtorNameShouldThrowExceptionWhenEmptyOrWhitespace = "Name should not be empty or whitespace!";
        private const string CtorDamageShouldThrowExceptionWhenNegativeOrZero = "Damage value should be positive!";
        private const string CtorHPShouldThrowExceptionWhenNegative = "HP should not be negative!";
        private const string Name = "Garo The Mighty";
        private const int Damage = 30;
        private const int HP = 100;
        private Warrior garicha;
        private const string EnemyName = "Okokorenia debelak";
        private const int EnemyDamage = 10;
        private const int EnemyHP = 100;
        private Warrior kokora;
        private const int MIN_ATTACK_HP = 30;
        private const string AttackAttackerHPUnderOrEqualTo30_MustThrowException = $"Enemy HP must be greater than 30 in order to attack him!";
        private const string AttackDefenderHPUnderOrEqualTo30MustThrowException = "Your HP is too low in order to attack other warriors!";
        private const string AttackAttackingEnemyWithDamageBiggerThanHPShouldThrowException = "You are trying to attack too strong enemy";

        [SetUp]
        public void SetUp()
        {
            garicha = new Warrior(Name, Damage, HP);
            kokora = new Warrior(EnemyName, EnemyDamage, EnemyHP);
        }

        [Test]
        public void Ctor_HappyPath_WarriorInitializesCorrectly()
        {
            Assert.IsNotNull(garicha);
            Assert.AreEqual(garicha.Name, Name);
            Assert.AreEqual(garicha.Damage, Damage);
            Assert.AreEqual(garicha.HP, HP);

        }

        [Test]
        public void Ctor_Name_ShouldThrowExceptionWhenEmptyOrWhitespace()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior testWarrior = new Warrior("", Damage, HP);
            });

            ArgumentException ex2 = Assert.Throws<ArgumentException>(() =>
            {
                Warrior testWarrior = new Warrior(" ", Damage, HP);
            });
            Assert.AreEqual(CtorNameShouldThrowExceptionWhenEmptyOrWhitespace, ex.Message);
            Assert.AreEqual(CtorNameShouldThrowExceptionWhenEmptyOrWhitespace, ex2.Message);
        }

        [Test]
        public void Ctor_Damage_ShouldThrowExceptionWhenNegativeOrZero()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior testWarrior = new Warrior(Name, -1, HP);

            });
            ArgumentException ex2 = Assert.Throws<ArgumentException>(() =>
            {
                Warrior testWarrior = new Warrior(Name, 0, HP);

            });
            Assert.AreEqual(CtorDamageShouldThrowExceptionWhenNegativeOrZero,ex.Message);
            Assert.AreEqual(CtorDamageShouldThrowExceptionWhenNegativeOrZero,ex2.Message);
        }

        [Test]
        public void Ctor_HP_ShouldThrowExceptionWhenNegative()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior testWarrior = new Warrior(Name, Damage, -1);

            });
            Assert.AreEqual(CtorHPShouldThrowExceptionWhenNegative,ex.Message);
        }

        [Test]
        public void Attack_HappyPath_FightingWorksCorrectly()
        {
            int expectedHealth = garicha.HP - kokora.Damage;
            kokora.Attack(garicha);
            Assert.AreEqual(garicha.HP, expectedHealth);
            int expectedEnemyHealth = kokora.HP - garicha.Damage;
            garicha.Attack(kokora);
            Assert.AreEqual(kokora.HP, expectedEnemyHealth);
        }

        [Test]
        public void Attack_HappyPath_DefenderDiesWhen0HP()
        {
            Warrior warrior = new("Surdok", 110, 100);
            warrior.Attack(kokora);
            int expecetedHP = 0;
            Assert.AreEqual(expecetedHP,kokora.HP);
        }
        [Test]
        public void Attack_AttackerHPUnderOrEqualTo30_MustThrowException()
        {
            garicha.Attack(kokora);
            garicha.Attack(kokora);
            garicha.Attack(kokora);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                garicha.Attack(kokora);
            });

            Assert.AreEqual(AttackAttackerHPUnderOrEqualTo30_MustThrowException, ex.Message);
        }

        [Test]
        public void Attack_DefenderHPUnderOrEqualTo30_MustThrowException()
        {
            Warrior warrior = new("Barahas", 20, 10);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => warrior.Attack(kokora));
            Assert.AreEqual(AttackDefenderHPUnderOrEqualTo30MustThrowException,ex.Message);
        }

        [Test]
        public void Attack_AttackingEnemyWithDamageBiggerThanHP_ShouldThrowException()
        {
            Warrior silas = new("SuperSila", 120, 140);
            Warrior slabas = new("Muhlis", 20, 40);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => slabas.Attack(silas));
            Assert.AreEqual(AttackAttackingEnemyWithDamageBiggerThanHPShouldThrowException, ex.Message);
        }
    }
}