using MyTeam.Entities;
using MyTeam.Gateways;
using System;
using System.Collections.Generic;

namespace MyTeam.TestUtilities.Gateways
{
    public class InMemoryTeamGateway : InMemoryGateway<Team>, ITeamGateway
    {
        public IEnumerable<Team> FindAllTeams()
        {
            return Entities.Values;
        }
    }
}
