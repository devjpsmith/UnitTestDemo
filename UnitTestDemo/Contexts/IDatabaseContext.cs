using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo

    /*
     * This could be a Database context provided by Entity Framework, or even another
     * database. All the technical logic for actually performing CRUD operations goes in here
     * IF you need to check any business logic, like only returning IsAlive persons, that 
     * needs to go into the PersonRepository.
     */
{
    /// <summary>
    /// Used to provide local data storage to the main application
    /// </summary>
    public interface IDatabaseContext
    {
        /*
         * Linq essentially allows us to perform CRUD operations on a List,
         *  so it will work well enough for the purposes of this demo
         */
        List<Person> Persons { get; }
    }
}
