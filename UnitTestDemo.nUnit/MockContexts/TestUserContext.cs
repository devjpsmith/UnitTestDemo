namespace UnitTestDemo.nUnit.MockContexts
{
    public class TestUserContext : IUserContext
    {
        public int GetCurrentPersonId()
        {
            return 1;
        }
    }
}
