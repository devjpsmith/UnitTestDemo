using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo
{
    /// <summary>
    /// This interface represents a class that would be used for managing the logged in user
    /// </summary>
    public interface IUserContext
    {
        /// <summary>
        /// Looks for the current logged in user and returns their Id from the Person table
        /// </summary>
        /// <returns></returns>
        int GetCurrentPersonId();
    }
}
