using System.Collections.Generic;
using System.Linq;

namespace UnitTestDemo.nUnit.MockContexts
{
    /// <summary>
    /// This is our mock api class, super simple just for testing purposes
    /// </summary>
    public class TestWebApiContext : IWebApiContext
    {
        // a simple storage device
        private IEnumerable<Person> _personList; 

        // get everyone from the personList
        public IEnumerable<Person> GetPersons()
        {
            return _personList;
        }

        // add data to the personList
        public void SeedData(IEnumerable<Person> persons)
        {
            _personList = persons;
        }

        // gets the desired record from the personList
        public Person GetPersonById(int Id)
        {
            return _personList.FirstOrDefault(p => p.Id == Id);
        }

    }
}
