using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories.Contracts;

namespace UnitTestDemo.nUnit.RepositoryTests.Mocks
{
    public class Mock_PersonRepository : IPersonRepository
    {
        public Person GetPersonById(int id)
        {
            return TestData.PersonTestData.ValidPersonsList.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetPersons()
        {
            return TestData.PersonTestData.ValidPersonsList;
        }

        public int SavePerson(Person person)
        {
            return 1;
        }

        public int SavePersons(IEnumerable<Person> persons)
        {
            return persons.Count();
        }
    }
}
