using MyTeam.TestUtilities;
using MyTeam.UseCases.PresentTeamSummaries;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

using static MyTeam.UseCases.UseCaseStatus;

namespace MyTeam.Specs.Steps
{
    [Binding]
    [Scope(Feature = "Present Teams")]
    public class WhenPresentTeams : When<PresentTeamSummaries>
    {
        private PresentTeamSummariesUseCase _userCase = new PresentTeamSummariesUseCase(TestFixture.Context);

        class PresentedTeamData
        {
            public string   Name;
            public int      NumberOfMembers;
            public string   Actions;
        }


        [When(@"I present teams")]
        public void WhenIPresentTeams()
        {
            Result = _userCase.PresentTeams();
        }

        [Then(@"no teams are presented")]
        public void ThenNoTeamsArePresented()
        {
            Assert.Equal(0, Result.TeamSummaryPresentations.Count());
        }

        [Then(@"The available actions contains (.*)")]
        public void ThenTheAvailableActionsContains(string action)
        {
            Assert.Equal(1, Result.Actions.Count());
            Assert.Equal(action, Result.Actions.Single());
        }

        [Then(@"no actions available")]
        public void ThenNoActionsAvailable()
        {
            Assert.Equal(0, Result.Actions.Count());
        }

        [Then(@"teams are presented")]
        public void ThenTeamsArePresented(Table table)
        {
            var teams = table.CreateSet<PresentedTeamData>();

            Assert.Equal(teams.Count(), Result.TeamSummaryPresentations.Count());
            foreach (var team in Result.TeamSummaryPresentations)
            {
                var teamData = teams.SingleOrDefault(c => c.Name == team.Name);
                Assert.NotNull(teamData);
                Assert.Equal(teamData.NumberOfMembers, team.NumberOfMembers);
            }
        }
    }
}
