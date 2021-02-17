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
            _useCase = new UserLoginUseCase();
        }

        [Test]
        public void WhenUserNotFoundThenAccessDenied()
        {
            var result = _useCase.Login("User", "Password");
            Assert.AreEqual(Unauthorized, result.Status);
        }
    }
}
