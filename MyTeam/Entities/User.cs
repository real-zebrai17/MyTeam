using System;
using System.Collections.Generic;
using System.Text;

namespace MyTeam.Entities
{
    public class User : Entity
    {
        public string UserName { get; set; }
        public UserRoles Roles { get; set; }

        public User(string userName)
        {
            UserName = userName;
        }

        public void AddRole(UserRoles role)
        {
            Roles = Roles | role;
        }
    }
}
