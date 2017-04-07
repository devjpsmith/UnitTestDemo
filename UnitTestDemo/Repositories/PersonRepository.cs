using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories.Contracts;

namespace UnitTestDemo.Repositories
{
    /*
     * This class puts a layer of abstraction between our application and the database.
     * All the business logic for CRUD operations can go in here.
     *     Maybe you need to only return persons where IsAlive == true,
     *     or maybe you need to ensure names all start with a capital letter followed by all lower case.
     *  All that logic goes in here, and it can all be put through automated testing with known data
     */
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
            // add any validation logic you want here
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
                // business logic could go here, for example
                //  each person gets validated and if one failes, 
                //  the business logic then decides if you insert the ones
                //  that passed, or reject them all. That's the kind of thing
                //  that goes in here.
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
