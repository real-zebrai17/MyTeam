using MyTeam.Entities;
using MyTeam.Gateways;
using System;
using System.Security.Cryptography;

namespace MyTeam.PasswordLockerService
{
    public class PasswordLocker : IPasswordLocker
    {
        private readonly IPasswordGateway _passwordLockerGateway;

        public PasswordLocker(IPasswordGateway passwordLockerGateway)
        {
            _passwordLockerGateway = passwordLockerGateway;
        }


        public void Set(Guid id, string password)
        {
            string passwordHash = HashPassword(password);

            _passwordLockerGateway.Save(new Password { Id = id, PasswordHash = passwordHash });
        }
        public bool Verify(Guid id, string password)
        {
            var passwordInfo = _passwordLockerGateway.FindById(id);
            return passwordInfo == null
                ? false 
                : Verify(password, passwordInfo.PasswordHash);
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        private static bool Verify(string password, string passwordHash)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }


    }
}
