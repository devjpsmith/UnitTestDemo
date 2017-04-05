using NUnit.Framework;
using System;
using UnitTestDemo.nUnit.MockContexts;
using UnitTestDemo.nUnit.RepositoryTests.Mocks;
using UnitTestDemo.Services.Contracts;

namespace UnitTestDemo.nUnit.ServiceTests
{
    public class BirthdayServiceTests
    {
        BirthdayService _birthdayService;
        TestDatabaseContext _database;
        TestUserContext _user;
        Mock_PersonService _personGreeterService;
        Mock_PersonRepository _personRepo;

        /*
         * By creating a mockup of the PersonGreeterService here,
         *  I can tightly control what each method in the class returns
         * This means when I test the BirthdayService, I am not
         *  relying on PersonGreeterService
         */
        class Mock_PersonService : IPersonGreeter
        {
            public string GreetPerson()
            {
                return "Hi";
            }
        }

        public BirthdayServiceTests()
        {
            _database = new TestDatabaseContext();
            _user = new TestUserContext();
            _personGreeterService = new Mock_PersonService();
            _personRepo = new Mock_PersonRepository();
            
            _birthdayService = new BirthdayService(_personRepo, _user, _personGreeterService);
        }

        [TestCase]
        public void ConstructorFailsWithNullParams()
        {
            // sanity checks
            Assert.Throws<ArgumentNullException>(() => new BirthdayService(_personRepo, null, null));
            Assert.Throws<ArgumentNullException>(() => new BirthdayService(null, _user, null));
            Assert.Throws<ArgumentNullException>(() => new BirthdayService(null, null, _personGreeterService));
            Assert.Throws<ArgumentNullException>(() => new BirthdayService(null, null, null));
        }

        [TestCase]
        public void ConstructorInitializesProperly()
        {
            // more sanity checks, and we can use this to initialize our local member
            Assert.DoesNotThrow(() => new BirthdayService(_personRepo, _user, _personGreeterService));
        }

        [TestCase]
        public void CelebrateBirthday()
        {
            // our mock context will return 1
            var id = _user.GetCurrentPersonId();
            // get the person from the mock db
            var person = _personRepo.GetPersonById(id);
            // set our expectation
            int expectedAge = person.Age + 1;
            // this is the function we are actually here to test
            var result = _birthdayService.CelebrateBirthday(person);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(Person), result);
            Assert.AreEqual(expectedAge, result.Age);
        }
    }
}
