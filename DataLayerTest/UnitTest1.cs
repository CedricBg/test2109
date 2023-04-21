using DataAccess.Models.Auth;

namespace DataAccessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddRegister()
        {
            AddRegisterForm form = new AddRegisterForm
            {
                Id = 1,
                Login = "cedric",
                Password = "aaaaaaaa",
            };
        }
    }
}