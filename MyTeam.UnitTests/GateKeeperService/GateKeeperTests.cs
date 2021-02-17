using MyTeam.Entities;
using MyTeam.GateKeeperService;
using NUnit.Framework;

namespace MyTeam.UnitTests.GateKeeperService
{
    [TestFixture]
    public class GateKeeperTests
    {
        [Test]
        public void NotLoggedIn()
        {
            Assert.False(new GateKeeper().IsLoggedIn);
        }

        [Test]
        public void WhenSetLoggedInUser()
        {
            var user = new User("User");
            var gateKeeper = new GateKeeper();
            gateKeeper.SetLoggedIn(user);
            Assert.IsTrue(gateKeeper.IsLoggedIn);
            Assert.AreEqual(user, gateKeeper.LoggedInUser);
        }
    }
}
