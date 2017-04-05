using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories.Contracts;
using UnitTestDemo.Services.Contracts;

namespace UnitTestDemo
{
    /*
     * see PersonRetreivalService for a full explaination
     */
    public class PersonGreeterService : IPersonGreeter
    {
        IPersonRepository _personRepo;
        IUserContext _user;

        public PersonGreeterService(IPersonRepository personRepo, IUserContext user)
        {
            _personRepo = personRepo ?? throw new ArgumentNullException(nameof(personRepo));
            _user = user ?? throw new ArgumentNullException(nameof(user));
        }

        /*
         * this is a great example of a method that might return a value that we're expecting in
         * another part of the program. Anyone could come along later and change the value and
         * it would not cause an immediate error when it's compiled, but might throw an
         * unexpected error at runtime or just cause some unexpected behaviour - it's hard and takes a lot 
         * of testing to catch every error like this by. If we are depending on
         * the result to be a certain value, add it to the tests and add some commenting! Now that testing
         * is automated and will be caught every time!
         */
        public string GreetPerson()
        {
            int id = _user.GetCurrentPersonId();
            var person = _personRepo.GetPersonById(id);
            return "Hello, " + person.FirstName + " " + person.LastName + ".";
        }
    }
}
