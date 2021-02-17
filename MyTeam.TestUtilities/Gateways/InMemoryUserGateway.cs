using MyTeam.Entities;
using MyTeam.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyTeam.TestUtilities.Gateways
{
    public class InMemoryUserGateway : InMemoryGateway<User>, IUserGateway
    {
        public User FindByUserName(string userName)
        {
            return (User)Entities.Values
                         .SingleOrDefault(u => u.UserName == userName)
                         ?.Clone();
        }
    }
}
