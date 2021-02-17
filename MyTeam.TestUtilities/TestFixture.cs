using MyTeam.GateKeeperService;
using MyTeam.PasswordLockerService;
using MyTeam.TestUtilities.Gateways;

namespace MyTeam.TestUtilities
{
    public static class TestFixture
    {
        public static IContext Context { get; private set; }
        public static void Setup()
        {
            Context = new Context(
                new InMemoryUserGateway(),
                new InMemoryTeamGateway(),
                new GateKeeper(),
                new PasswordLocker(new InMemoryPasswordGateway()));
        }
    }
}
