using MyTeam.GateKeeperService;
using MyTeam.Gateways;
using MyTeam.PasswordLockerService;

namespace MyTeam
{
    public class Context : IContext
    {

        public Context(IUserGateway userGateway, ITeamGateway teamGateway, IGateKeeper gateKeeper, IPasswordLocker passwordLocker)
        {
            UserGateway = userGateway;
            TeamGateway = teamGateway;
            GateKeeper = gateKeeper;
            PasswordLocker = passwordLocker;
        }

        public IUserGateway UserGateway { get; set; }

        public ITeamGateway TeamGateway { get; set; }
        public IGateKeeper GateKeeper { get; set; }
        public IPasswordLocker PasswordLocker { get; set; }
    }
}
