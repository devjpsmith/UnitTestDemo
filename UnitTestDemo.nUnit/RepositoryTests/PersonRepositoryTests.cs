using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.nUnit.MockContexts;
using UnitTestDemo.Repositories;

namespace UnitTestDemo.nUnit.RepositoryTests
{
    public class PersonRepositoryTests
    {
        private TestDatabaseContext _database;
        private PersonRepository _personRepo;
        
        public PersonRepositoryTests()
        {
            _database = new TestDatabaseContext();

            _database.SeedData(TestData.PersonTestData.ValidPersonsList);

            _personRepo = new PersonRepository(_database);
        }

        [TestCase]
        public void ConstructorFailsWithNullParams()
        {
            Assert.Throws<ArgumentNullException>(() => new PersonRepository(null));
        }

        [TestCase(1, "Billy")]
        [TestCase(2, "Sally")]
        [TestCase(3, "Garry")]
        public void GetPersonWorks(int id, string firstName)
        {
            var result = _personRepo.GetPersonById(id);
            Assert.AreEqual(expected: firstName, actual: result.FirstName);
        }

        [TestCase]
        public void GetPersonsWorks()
        {
            // reset the database
            _database.SeedData(TestData.PersonTestData.ValidPersonsList);
            var result = _personRepo.GetPersons();
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestCase]
        public void SavePersonWorks()
        {
            var person = new Person() { Id = 4, Age = 45, FirstName = "Rusty", LastName = "Shackleford" };
            var result = _personRepo.SavePerson(person);
            Assert.AreEqual(1, result); // saving a new person should return 1

            result = _personRepo.SavePerson(person);
            Assert.AreEqual(0, result); // saving an existing person should return 0
        }

        [TestCase]
        public void SavePersonsWorks()
        {
            List<Person> persons = new List<Person>()
            {
                new Person()
                {
                    Id = 5, 
                    Age = 50,
                    FirstName = "Bobby",
                    LastName = "Blue"
                },
                new Person()
                {
                    Id = 6,
                    Age = 55,
                    FirstName = "Polly",
                    LastName = "Pink"
                },
            };

            var result = _personRepo.SavePersons(persons);
            Assert.AreEqual(2, result);
        }

    }
}
