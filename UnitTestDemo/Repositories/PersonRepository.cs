using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories.Contracts;

namespace UnitTestDemo.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        IDatabaseContext _database;

        public PersonRepository(IDatabaseContext database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public Person GetPersonById(int id)
        {
            return _database.Persons.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _database.Persons;
        }

        public int SavePerson(Person person)
        {
            if (!_database.Persons.Contains(person))
            {
                _database.Persons.Add(person);
                return 1;
            }
            return 0;
        }

        public int SavePersons(IEnumerable<Person> persons)
        {
            int count = 0;
            foreach (var person in persons)
            {
                if (!_database.Persons.Contains(person))
                {
                    _database.Persons.Add(person);
                    count++;
                }
            }
            return count;
        }
    }
}
