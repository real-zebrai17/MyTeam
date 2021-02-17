using MyTeam.Entities;
using MyTeam.TestUtilities;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MyTeam.Specs.Steps
{
    [Binding]
    public class GivenTeams
    {
        public class TeamData 
        {
            public string name;
        }

        [Given(@"The following Teams exist")]
        public void GivenTheFollowingTeamsExist(Table table)
        {
            foreach (var team in table.CreateSet<TeamData>())
            {
                TestFixture.Context.TeamGateway.Save(new Team { Name = team.name });
            }
        }
    }
}
