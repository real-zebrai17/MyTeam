using MyTeam.Entities;
using System;

namespace MyTeam.Gateways
{
    public interface IPasswordGateway
    {
        Password Save(Password team);
        Password FindById(Guid id);
    }
}
