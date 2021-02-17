using MyTeam.Entities;
using MyTeam.Gateways;
using System;
using System.Linq;

namespace MyTeam.TestUtilities.Gateways
{
    public class InMemoryPasswordGateway : InMemoryGateway<Password>, IPasswordGateway
    {
        public Password FindById(Guid id)
        {
            if (!Entities.ContainsKey(id)) return null;
            return Entities[id];
        }
    }
}
