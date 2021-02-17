using MyTeam.TestUtilities;
using NUnit.Framework;
using System;

namespace MyTeam.UnitTests.PasswordLockerService
{
    [TestFixture]
    public class PasswordLockerTest
    {
        [SetUp]
        public void SetUp()
        {
            TestFixture.Setup();
        }

        [Test]
        public void WhenPasswordSetThenVerifyWithWrongPasswordVerifyReturnsFalse()
        {
            var userId = Guid.NewGuid();
            TestFixture.Context.PasswordLocker.Set(userId, "Password");
            Assert.IsFalse(TestFixture.Context.PasswordLocker.Verify(userId, "WrongPassword"));
        }

        [Test]
        public void WhenPasswordSetThenVerifyWithCorrectPasswordVerifyReturnsFalse()
        {
            var userId = Guid.NewGuid();
            TestFixture.Context.PasswordLocker.Set(userId, "Password");
            Assert.True(TestFixture.Context.PasswordLocker.Verify(userId, "Password"));
        }

        [Test]
        public void WehnIdNotFoundReturnFalse()
        {
            Assert.False(TestFixture.Context.PasswordLocker.Verify(Guid.NewGuid(), "Password"));
        }
    }
}

