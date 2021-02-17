using MyTeam.Entities;
using MyTeam.TestUtilities;
using MyTeam.UseCases.UserLogin;
using NUnit.Framework;
using static MyTeam.UseCases.UseCaseStatus;

namespace MyTeam.UnitTests.UseCase.UserLogin
{
    [TestFixture]
    public class UserLoginUseCaseTest
    {
        private UserLoginUseCase _useCase;

        [SetUp]
        public void SetUp()
        {
            TestFixture.Setup();
            _useCase = new UserLoginUseCase(TestFixture.Context);
        }

        [Test]
        public void WhenUserNotFoundThenAccessDenied()
        {
            var result = _useCase.Login("User", "Password");
            Assert.AreEqual(Unauthorized, result.Status);
        }

        class WithExistingUserAndCorrectPassword : UserLoginUseCaseTest
        {
            private User _user;
            [SetUp]
            public void SetUpInner()
            {
                _user = TestFixture.Context.UserGateway.Save(new User("User1"));
                TestFixture.Context.PasswordLocker.Set(_user.Id.Value, "Password");
            }

            [Test]
            public void LoginSuccessfull()
            {
                var result = _useCase.Login(_user.UserName, "Password");
                Assert.AreEqual(Ok, result.Status);
                Assert.IsTrue(_user.SameAs(result.User));
            }
        }

        class WithExistingUserAndIncorrectPassword : UserLoginUseCaseTest
        {
            private User _user;
            [SetUp]
            public void SetUpInner()
            {
                _user = TestFixture.Context.UserGateway.Save(new User("User1"));
                TestFixture.Context.PasswordLocker.Set(_user.Id.Value, "Password");
            }

            [Test]
            public void LoginFails()
            {
                var result = _useCase.Login(_user.UserName, "P@ssw0rd");
                Assert.AreEqual(Unauthorized, result.Status);
                Assert.Null(result.User);
            }
        }
    }
}
