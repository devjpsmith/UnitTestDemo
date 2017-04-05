using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestDemo.nUnit.MockContexts
{
    /// <summary>
    /// Mock database context used for testing
    /// This allows us to work with known sets of static data
    /// </summary>
    public class TestDatabaseContext : IDatabaseContext
    {
        public List<Person> Persons { get; private set; }


        public TestDatabaseContext()
        {
            // instantiate each table you add to the class in the constructor
            Persons = new List<Person>();
        }

        // with a normal EF context, you would not need this.
        public void SeedData(IEnumerable<Person> persons)
        {
            Persons = persons.ToList();
        }
        
    }
}
