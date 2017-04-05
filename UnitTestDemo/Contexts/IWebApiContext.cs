using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    /// <summary>
    /// Used to provide web service functionality to the main application
    /// </summary>
    public interface IWebApiContext
    {
        /// <summary>
        /// Get all Person records from the cloud
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> GetPersons();

        /// <summary>
        /// Get a single Person record from the could, by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Person GetPersonById(int Id);
    }
}
