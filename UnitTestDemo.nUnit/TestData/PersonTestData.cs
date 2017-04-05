using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo.nUnit.TestData
{
    /// <summary>
    /// static data. Be aware that changes here could affect test results.
    /// The idea here is that we're able to work with a known dataset.
    /// We 100% control what is going into our mock storage objects, so we can 
    ///     easily predict what is should be coming out as the results
    ///     of methods working on the data
    /// </summary>
    public static class PersonTestData
    {
        public static List<Person> ValidPersonsList = new List<Person>()
            {
                new Person()
        {
            Id = 1,
                    FirstName = "Billy",
                    LastName = "Black",
                    Age = 25
                },
                new Person()
        {
            Id = 2,
                    FirstName = "Sally",
                    LastName = "Silver",
                    Age = 30
                },
                new Person()
        {
            Id = 3,
                    FirstName = "Garry",
                    LastName = "Gray",
                    Age = 35
                }
    };
}
}
