using NUnit.Framework;
using System;
using UnitTestDemo.nUnit.MockContexts;
using UnitTestDemo.nUnit.RepositoryTests.Mocks;

namespace UnitTestDemo.nUnit.ServiceTests
{
    public class PersonGreeterTests
    {
        PersonGreeterService _greeterService;
        Mock_PersonRepository _personRepo;
        TestUserContext _user;

        public PersonGreeterTests()
        {
            _personRepo = new Mock_PersonRepository();
            _user = new TestUserContext();
            
            _greeterService = new PersonGreeterService(_personRepo, _user);
        }

        [TestCase]
        public void ConstructorFailsWithNullParams()
        {
            Assert.Throws<ArgumentNullException>(() => new PersonGreeterService(_personRepo, null));
            Assert.Throws<ArgumentNullException>(() => new PersonGreeterService(null, _user));
            Assert.Throws<ArgumentNullException>(() => new PersonGreeterService(null, null));
        }

        [TestCase]
        public void ConstructorInitializesProperly()
        {
            Assert.DoesNotThrow(() => new PersonGreeterService(_personRepo, _user));
        }

        [TestCase]
        public void GreetPersonShouldWork()
        {
            var result = _greeterService.GreetPerson();
            Assert.IsInstanceOf(typeof(string), result);
            Assert.AreEqual("Hello, Billy Black.", result);
        }
    }
}
