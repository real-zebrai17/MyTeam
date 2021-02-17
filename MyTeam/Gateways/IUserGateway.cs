using MyTeam.Entities;

namespace MyTeam.Gateways
{
    public interface IUserGateway
    {
        User Save(User user);
        User FindByUserName(string userName);
    }
}
