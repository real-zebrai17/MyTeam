using static MyTeam.UseCases.UseCaseStatus;
using MyTeam.UseCases.UserLogin;
using TechTalk.SpecFlow;
using Xunit;
using MyTeam.TestUtilities;

namespace MyTeam.Specs.Steps
{
    [Binding]
    [Scope(Feature = "User Login")]
    public class WhenUserLogsIn : When<LoginResult>
    {
        private readonly UserLoginUseCase _useCase = new UserLoginUseCase(TestFixture.Context);

        [When(@"User Logs in with (.*) User and (.*)")]
        public void WhenUserLogsInWithUserAnd(string userName, string password)
        {
            Result = _useCase.Login(userName, password);
        }

        [Then(@"Login user Is Null")]
        public void ThenLoginUserIsNull()
        {
            Assert.Null(Result.User);
        }

        [Then(@"Login user set to (.*)")]
        public void ThenLoginUserSetTo(string userName)
        {
            var user = TestFixture.Context.UserGateway.FindByUserName(userName);
            Assert.True(Result.User.SameAs(user));
        }

    }
}
