using MyTeam.Entities;
using NUnit.Framework;

namespace MyTeam.UnitTests.Entities
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void WhenUserAdminUserRoleIsSetThenUserRolesContainAdmin()
        {
            User user = new User("User");
            user.AddRole(UserRoles.Admin);

            Assert.True(user.Roles.HasFlag(UserRoles.Admin));
        }
    }
}
