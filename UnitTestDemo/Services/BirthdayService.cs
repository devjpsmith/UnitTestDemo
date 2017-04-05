using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories.Contracts;
using UnitTestDemo.Services.Contracts;

namespace UnitTestDemo
{
    public class BirthdayService
    {
        /*
         * go look at PersonRetreivalService for a full explaination of what's going on here
         */
        IUserContext _user;
        IPersonGreeter _personGreeterService;
        IPersonRepository _personRepo;

        public BirthdayService(IPersonRepository personRepo, IUserContext user, IPersonGreeter personGreeter)
        {
            _personRepo = personRepo ?? throw new ArgumentNullException(nameof(personRepo));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            // If we had just created our own...
            //      _personGreeterService = new PersonGreeterService();
            //  but, it would make BirthdayService dependant on PersonGreetingService.
            // By using dependency injection, we are able to test BirthdayService independently
            //  in our unit tests
            _personGreeterService = personGreeter ?? throw new ArgumentNullException(nameof(personGreeter));
        }

        /* 
         * This method is a great example of where we want to perform some business logic on
         * some data, and it should come back in a predicatable way
         */
        public Person CelebrateBirthday(Person person)
        {
            person.Age++;

            _personRepo.SavePerson(person);

            Console.WriteLine(_personGreeterService.GreetPerson() + ". Congratulations on evading death one more year.");

            _personRepo.GetPersonById(person.Id);

            return person;
            
        }
    }
}
