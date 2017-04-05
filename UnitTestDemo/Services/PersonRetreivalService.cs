using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestDemo.Repositories.Contracts;

namespace UnitTestDemo
{
    public class PersonRetreivalService
    {
        IPersonRepository _personRepo;
        IWebApiContext _api;

        public PersonRetreivalService(IPersonRepository personRepo, IWebApiContext api)
        {
            /*
             * So, we need to work with a DB connection and a web service client in this class.
             * Why not just create them here?
             * You could write:
             *      _database = new DatabaseContext();
             * 
             * ...but, with that one line, you've intertwined your PersonRetreivalService logic with the 
             * database logic. Now, if we want to write automated tests, you can't test PersonRetreivalService
             * without inherently testing the database methods as well. This migh sound good at first, but
             * the problem is, when your SyncPersons method fails the tests, was it because something went wrong
             * in this class or is it something in the database that is causing the problem?
             * 
             * Also, if you create the web service client here, every time you run your tests, you depend on data
             *  coming from the actual web service. That data is not static; it is not 100% known data. You cannot
             *  predict the results when the data is not known. You cannot put in specific tests, like:
             *      Get Person where Id == 1, and his FirstName should be 'Billy'
             * 
             * So, the better solution is to require a database context in the constructor. That way, when we want
             * to perform automated testing, we can just send in some simple database object that we build ourselves
             * entirely for the purpose of testing. That database we pass in can contain a known set of data so that
             * we can predict the results!
             */

            // set the local variables with the arguments from the constructor
            // Is this a real database, or one that's mocked up for testing?
            // I don't really care, as long as it works!!!
            _personRepo = personRepo ?? throw new ArgumentNullException(nameof(personRepo)); 
            // same with the api. As long as whatever got passed in implements
            //  the GetPersons method, I don't give a shit what it is!!!
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        /*
         * This method looks small, but it could be a whole lot bigger!
         * In a real application, there might be hundreds of lines of validation code,
         * or some other business logic that manipulates the data from online before 
         * allowing it to go into our local database. In order to test all this business
         * logic, I would want to be able to get some known data from the api, and then I could
         * predict what the result would be. Maybe I want to test that this method won't save 
         * an object that doesn't have a propety set - I can just pass that in using my mocked up
         * api, and it should behave the way I expect!
         */
        public int SyncPersons()
        {
            int counter = 0;
            var persons = _api.GetPersons();
            foreach (var person in persons)
            {
                counter += _personRepo.SavePerson(person);
            }
            return counter;
        }
    }
}
