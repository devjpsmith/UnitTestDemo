using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories;

namespace UnitTestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                we're not actually doing anything in this program.
                the purpose is to test the classes we have written.

                We could pretend this is a screen, activity, page, etc... of a live application
                We would create some of our objects here
                Let's just start off with creating some "contexts" that we'll need for instantiating our classes
            */
            PersonRepository personRepo = new PersonRepository(new DatabaseContext());

            // First we'll create a PersonRetreivalService to download some data
            PersonRetreivalService personRetreivalService = new PersonRetreivalService(personRepo, new WebApiContext());
            // Now we could call this service's methods to download some data
            //  the service would get data from the API and save it locally in the database

            // Next, we will greet the current user. To do so, we'd need a PersonGreeterService
            PersonGreeterService personGreeterService = new PersonGreeterService(personRepo, new UserContext());
            // now we could call personGreeterService.GreetPerson() and output to the UI

            // Next we might want to celebrate the user's birthday on a button click, or some other event
            BirthdayService birthdayService = new BirthdayService(personRepo, new UserContext(), personGreeterService);
            // and now we would be able to call birthdayService.CelebrateBirthday()

            /*
                You wouldn't use this pattern for every single class you're creating here
                There's no reason you can't just create a new Person (for example), or some other
                    system objects like new Collections
                What you do want to try to do is tuck your business logic away into modular components and 
                    keep stuff like your database code and web service code tucked away in some other layer 
                    of abstraction. If your database code is intertwined with your business logic, it's 
                    impossible to automate the testing on that. Your Business logic depends on the DB logic and you
                    won't know what's broken without the usual lengthy debugging process.

                This is called dependency injection.

                Now, we should go look inside PersonRetreivalService to understand why, exactly we're using this pattern    
            */
        }

        class DatabaseContext : IDatabaseContext
        {
            public List<Person> Persons => throw new NotImplementedException();
        }

        class UserContext : IUserContext
        {
            public int GetCurrentPersonId()
            {
                throw new NotImplementedException();
            }
        }

        class WebApiContext : IWebApiContext
        {
            public Person GetPersonById(int Id)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Person> GetPersons()
            {
                throw new NotImplementedException();
            }
        }

    }
}
