using System.Linq;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {   
        private const int CornerCaseInvalidNumberOfPeople = 17;
        private const int MaxNumberOfPeople = 16;
        private const string AddRangeExpectedException = "Provided data length should be in range [0..16]!";
        private const string AddMaxNumReachedExpectedException = "Array's capacity must be exactly 16 integers!";
        private const string AddUserNameExistsExpectedException = "There is already user with this username!";
        private const string AddUserIdExistsExpectedException = "There is already user with this Id!";
        private const string FindById_UserNotFound_ExpectedException = "No user is present by this ID!";
        private const string UserNamePehso = "pesho123";
        private const string UserNameIvan = "ivan2323";
        private const long IdIvan = 100002;
        private const long IdPehso = 100001;
        
        //System Under Test
        Database sut;

        [SetUp]
        public void SetUp()
        {

            Person pesho = new Person(IdPehso, UserNamePehso);
            Person ivan = new Person(IdIvan, UserNameIvan);
            Person[] people = new Person[] { pesho, ivan };
            sut = new Database(people);
        }

        [Test]
        public void Ctor_EmptyWithValidParameters_CreatesNewInstance()
        {
            Database db = new Database();
            Assert.IsNotNull(db);
            Assert.AreEqual(db.Count, 0);
        }
        [Test]
        public void Ctor_WithValidParameters_CreatesNewInstance()
        {
            int actualResult = 2;
            Assert.IsNotNull(sut);
            Assert.AreEqual(sut.Count, actualResult);
        }

        [Test]
        public void Ctor_WithTooManyPeople_ThrowsException()
        {
            Person[] tooManyPeople = new Person[CornerCaseInvalidNumberOfPeople];

            for (int i = 0; i < CornerCaseInvalidNumberOfPeople; i++)
            {
                tooManyPeople[i] = new Person(IdPehso + i, $"{UserNamePehso}+{i}");
            }

            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                new Database(tooManyPeople);
            });

            Assert.AreEqual(AddRangeExpectedException,ex.Message);
        }

        [Test]

        public void Add_HappyPath_AddsNewPerson()
        {
            Person maria = new Person(IdIvan+1, "Maria");
            sut.Add(maria);
            Assert.AreEqual(sut.Count,3);
        }

        [Test]
        public void Add_DatabaseIsFull_ThrowsException()
        {

            sut = new Database();

            for (int i = 0; i < MaxNumberOfPeople; i++)
            {
                sut.Add(new Person (200000+i,$"{UserNameIvan}{i}"));
            }

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Add(new Person(205000, $"Siri"));
            });

            Assert.AreEqual(AddMaxNumReachedExpectedException,ex.Message);
        }

        [Test]

        public void Add_UserNameExists_ExpectedException()
        {   

            Person expectedPerson = sut.FindByUsername(UserNamePehso);
            //Person actualPerson = new Person(IdPehso, UserNamePehso);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Add(expectedPerson);
            });

            Assert.AreEqual(AddUserNameExistsExpectedException,ex.Message);
        }

        [Test]
        public void Add_UserIdExists_ExpectedException()
        {
            Person expectedPerson = new(IdPehso, "Jerry");
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Add(expectedPerson);
            });

            Assert.AreEqual(AddUserIdExistsExpectedException, ex.Message);
            
        }

        [Test]
        public void Remove_WhenArrayEmpty_ShouldThrowException()
        {
            sut.Remove();
            sut.Remove();
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Remove();
            });
        }

        [Test]
        public void Remove_ShouldRemoveElement()
        {
            int expectedResult = 1;
            sut.Remove();
            Assert.AreEqual(expectedResult,sut.Count);
        }

        [Test]
        public void FindByUsername_HappyPath_ReturnsUser()
        {
            Person peshoFound = sut.FindByUsername(UserNamePehso);
            Assert.IsNotNull(peshoFound);
            Assert.AreEqual(peshoFound.UserName,UserNamePehso);
            Assert.AreEqual(peshoFound.Id,IdPehso);
        }

        [Test]

        public void FindByUsername_ShouldThrowException_WhenUserNameEmpty()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                sut.FindByUsername(null);
            });
        }

        [Test]
        public void FindByUsername_ShouldThrowException_WhenUserNameWhitespace()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                sut.FindByUsername(" ");
            });
        }

        [Test]

        public void FindById_HappyPath_ReturnsUser()
        {
            Person peshoFound = sut.FindById(IdPehso);
            Assert.IsNotNull(peshoFound);
            Assert.AreEqual(peshoFound.UserName, UserNamePehso);
            Assert.AreEqual(peshoFound.Id, IdPehso);
        }

        [Test]

        public void FindById_ShouldThrowException_WhenIdLessThan0()
        {
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                sut.FindById(-1);
            });
        }

        [Test]
        public void FindById_ShouldThrowException_UserNotFound()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                sut.FindById(101010101010101);
            });

            Assert.AreEqual(FindById_UserNotFound_ExpectedException,ex.Message);
        }
    }
}