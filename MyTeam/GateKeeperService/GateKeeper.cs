using MyTeam.Entities;

namespace MyTeam.GateKeeperService
{
    //TODO Add Tests
    public class GateKeeper : IGateKeeper
    {
        public void SetLoggedIn(User user)
        {
            LoggedInUser = user;
        }

        public User LoggedInUser { get; private set; }

        public bool IsLoggedIn => LoggedInUser != null;
    }
}
