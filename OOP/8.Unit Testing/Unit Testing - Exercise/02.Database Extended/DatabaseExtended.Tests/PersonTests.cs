using ExtendedDatabase;
using NUnit.Framework;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class PersonTests
    {
        private const string UserName = "pesho123";
        private const long Id = 100001;

        [Test]
        public void Ctor_WithValidParameters_CreateNewInstance()
        {   
            //Getters
            Person person = new Person(Id, UserName);
            //Assert.NotNull(person);
            Assert.That(person,Is.Not.Null);
            //Setters
            Assert.That(person.Id, Is.EqualTo(Id));
            Assert.That(person.UserName, Is.EqualTo(UserName));
        }
    }
}
