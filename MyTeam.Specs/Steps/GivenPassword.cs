using MyTeam.TestUtilities;
using TechTalk.SpecFlow;

namespace MyTeam.Specs.Steps
{
    [Binding]
    public class GivenPassword
    {
        [Given(@"Password for (.*) is set to (.*)")]
        public void GivenPasswordForIsSetTo(string userName, string password)
        {
            var user = TestFixture.Context.UserGateway.FindByUserName(userName);
            TestFixture.Context.PasswordLocker.Set(user.Id.Value, password);
        }
    }
}
