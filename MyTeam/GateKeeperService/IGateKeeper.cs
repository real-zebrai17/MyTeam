using MyTeam.Entities;

namespace MyTeam.GateKeeperService
{
    public interface IGateKeeper
    {
        User LoggedInUser { get; }

        void SetLoggedIn(User user);
        bool IsLoggedIn { get; }
    }
}