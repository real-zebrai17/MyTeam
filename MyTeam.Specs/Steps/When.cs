using MyTeam.UseCases;
using MyTeam.UseCases.PresentTeamSummaries;
using TechTalk.SpecFlow;
using Xunit;

using static MyTeam.UseCases.UseCaseStatus; 

namespace MyTeam.Specs.Steps
{
    public class When<T> where T : UseCaseResult
    {
        protected T  Result { get; set; }

        [Then(@"Unauthorized")]
        public void ThenUnauthorized()
        {
            Assert.Equal(Unauthorized, Result.Status);
        }

        [Then(@"Success")]
        public void ThenSuccess()
        {
            Assert.Equal(Ok, Result.Status);
        }
    }
}
