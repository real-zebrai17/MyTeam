using MyTeam.GateKeeperService;
using MyTeam.Gateways;
using MyTeam.PasswordLockerService;

namespace MyTeam
{
    public interface IContext
    {
        IGateKeeper GateKeeper { get; set; }
        ITeamGateway TeamGateway { get; set; }
        IUserGateway UserGateway { get; set; }
        IPasswordLocker PasswordLocker { get; set; }
    }
}