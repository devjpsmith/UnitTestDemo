using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo.Repositories.Contracts
{
    public interface IPersonRepository
    {
        Person GetPersonById(int id);

        IEnumerable<Person> GetPersons();

        int SavePersons(IEnumerable<Person> persons);

        int SavePerson(Person person);
    }
}
