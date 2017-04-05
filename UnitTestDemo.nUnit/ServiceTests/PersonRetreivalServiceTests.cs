using NUnit.Framework;
using System;
using UnitTestDemo.nUnit.MockContexts;
using UnitTestDemo.nUnit.RepositoryTests.Mocks;

namespace UnitTestDemo.nUnit.ServiceTests
{
    public class PersonRetreivalServiceTests
    {
        PersonRetreivalService _personRetreivalService;
        Mock_PersonRepository _personRepo;
        TestWebApiContext _api;

        public PersonRetreivalServiceTests()
        {
            _personRepo = new Mock_PersonRepository();
            _api = new TestWebApiContext();

            // add some seed data to the api
            _api.SeedData(nUnit.TestData.PersonTestData.ValidPersonsList);
            _personRetreivalService = new PersonRetreivalService(_personRepo, _api);
        }

        [TestCase]
        public void ConstructorFailsWithNullParams()
        {
            Assert.Throws<ArgumentNullException>(() => new PersonRetreivalService(_personRepo, null));
            Assert.Throws<ArgumentNullException>(() => new PersonRetreivalService(null, _api));
            Assert.Throws<ArgumentNullException>(() => new PersonRetreivalService(null, null));
        }

        [TestCase]
        public void ConstructorInitializesProperly()
        {
            // sanity check - don't just assume the object will create properly; verify with testing!!!
            Assert.DoesNotThrow(() => new PersonRetreivalService(_personRepo, _api));
        }

        [TestCase]
        public void SyncPersonsShouldWork()
        {
            // remember, put each public method on a class through a test
            var result = _personRetreivalService.SyncPersons();
            Assert.IsInstanceOf(typeof(int), result);
            Assert.AreEqual(3, result); // we loaded 3 into the api, so...
        }
    }
}
