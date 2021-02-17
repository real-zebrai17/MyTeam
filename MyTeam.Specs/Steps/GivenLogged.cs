using MyTeam.Entities;
using MyTeam.TestUtilities;
using TechTalk.SpecFlow;

namespace MyTeam.Specs.Steps
{
    [Binding]
    public class GivenLogged
    {
        [Given(@"User (.*) is Logged In")]
        public void GivenUserIsLoggedIn(string userName)
        {
            User user = TestFixture.Context.UserGateway.FindByUserName(userName);
            TestFixture.Context.GateKeeper.SetLoggedIn(user);
        }

    }
}
