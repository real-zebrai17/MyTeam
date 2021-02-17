using System;

namespace MyTeam.PasswordLockerService
{
    public interface IPasswordLocker
    {
        void Set(Guid id, string password);
        bool Verify(Guid id, string password);
    }
}
