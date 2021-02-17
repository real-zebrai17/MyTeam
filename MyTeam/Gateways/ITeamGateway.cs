using MyTeam.Entities;
using System.Collections.Generic;

namespace MyTeam.Gateways
{
    public interface ITeamGateway
    {
        Team Save(Team team);
        IEnumerable<Team> FindAllTeams();
    }
}
