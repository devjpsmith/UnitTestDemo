using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    /// <summary>
    /// An example Data model
    /// </summary>
    /// <remarks>This model would be a table in the database</remarks>
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
