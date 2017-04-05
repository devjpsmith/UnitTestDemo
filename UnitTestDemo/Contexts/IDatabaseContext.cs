using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    /// <summary>
    /// Used to provide local data storage to the main application
    /// </summary>
    public interface IDatabaseContext
    {
        List<Person> Persons { get; }
    }
}
