using MyTeam.TestUtilities;
using MyTeam.UseCases;
using MyTeam.UseCases.SetUserPassword;
using TechTalk.SpecFlow;
using Xunit;

namespace MyTeam.Specs.Steps
{
    [Binding]
    [Scope(Feature = "Set User Password")]
    public class WhenUserPasswordSet : When<UseCaseResult>
    {
        private readonly SetUserPasswordUserCase _useCase = new SetUserPasswordUserCase(TestFixture.Context);

        [When(@"I set user (.*)'s password to (.*)")]
        public void WhenISetUserPasswordTo(string userName, string password)
        {
            Result = _useCase.SetUserPassword(userName, password);
        }

        [Then(@"Password for user (.*) is set to (.*)")]
        public void ThenPasswordForUserIsSetTo(string userName, string password)
        {
            var user = TestFixture.Context.UserGateway.FindByUserName(userName);
            Assert.True(TestFixture.Context.PasswordLocker.Verify(user.Id.Value, password));
        }
    }
}
