using TechTalk.SpecFlow;
using MyTeam.Entities;
using System;
using System.Linq;
using MyTeam.TestUtilities;

namespace MyTeam.Specs.Steps
{
    [Binding]
    public class GivenUser
    {
        [Given(@"User (.*) Exists")]
        public void GivenUserExists(string userName)
        {
            TestFixture.Context.UserGateway.Save(new User(userName));
        }

        [Given(@"User (.*) is in (.*) Role")]
        public void GivenUserIsInRole(string userName, string roleName)
        {
            var user = TestFixture.Context.UserGateway.FindByUserName(userName);
            user.AddRole((UserRoles)Enum.Parse(typeof(UserRoles), roleName));

            TestFixture.Context.UserGateway.Save(user);
        }
    }
}
