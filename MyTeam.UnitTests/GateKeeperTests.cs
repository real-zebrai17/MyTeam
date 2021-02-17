using MyTeam.Entities;
using MyTeam.GateKeeperService;
using NUnit.Framework;

namespace MyTeam.UnitTests
{
    [TestFixture]
    public class GateKeeperTests
    {
        [Test]
        public void WhenCreatedLoggedInUserIsNull()
        {
            var gateKeeper = new GateKeeper();
            Assert.Null(gateKeeper.LoggedInUser);
        }

        [Test]
        public void SetLoggedInUser()
        {
            var user = new User("User");
            var gateKeeper = new GateKeeper();
            gateKeeper.SetLoggedIn(user);

            Assert.AreSame(user, gateKeeper.LoggedInUser);
        }
    }
}
