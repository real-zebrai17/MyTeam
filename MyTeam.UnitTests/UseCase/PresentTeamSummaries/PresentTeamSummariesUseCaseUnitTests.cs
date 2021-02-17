using MyTeam.Entities;
using MyTeam.TestUtilities;
using static MyTeam.UseCases.UseCaseStatus;
using MyTeam.UseCases.PresentTeamSummaries;
using NUnit.Framework;
using System.Linq;

namespace MyTeam.UnitTests.UseCase.PresentTeamSummaries
{
    [TestFixture]
    public class PresentTeamSummariesUseCaseUnitTests
    {

        public PresentTeamSummariesUseCase _useCase;

        [SetUp]
        public void SetUp()
        {
            TestFixture.Setup();
            _useCase = new PresentTeamSummariesUseCase(TestFixture.Context);
        }

        class WithAdminUser : PresentTeamSummariesUseCaseUnitTests
        {

            [SetUp]
            public void SetUp()
            {
                var user = new User("User");
                user.AddRole(UserRoles.Admin);
                TestFixture.Context.GateKeeper.SetLoggedIn(user);

                
            }


            [Test]
            public void GetActionForRolesContainingAdminReturnsCreate()
            {
                User user = new User("User");
                user.AddRole(UserRoles.Admin);
                TestFixture.Context.GateKeeper.SetLoggedIn(user);

                var expected = new[] { "Create" };
                var result = _useCase.PresentTeams();
                Assert.AreEqual(expected, result.Actions);
            }
        }

        class WithNoRoles : PresentTeamSummariesUseCaseUnitTests
        {

            [SetUp]
            public void SetUp()
            {
                User user = new User("User");
                TestFixture.Context.GateKeeper.SetLoggedIn(user);
            }

            [Test]
            public void GetActionForRolesWithNotContainingAdminReturnsCreate()
            {
                var expectedActions = new string[] { };
                var presentation = _useCase.PresentTeams();

                Assert.AreEqual(expectedActions, presentation.Actions);
                Assert.AreEqual(0, presentation.TeamSummaryPresentations.Count());
            }

            [Test]
            public void TeamIsPresented()
            {
                TestFixture.Context.TeamGateway.Save(new Team { Name = "Team A" });
                var expectedActions = new string[] { };
                var presentation = _useCase.PresentTeams();

                Assert.AreEqual(expectedActions, presentation.Actions);
                Assert.AreEqual(1, presentation.TeamSummaryPresentations.Count());

                Assert.AreEqual("Team A", presentation.TeamSummaryPresentations[0].Name);
                Assert.AreEqual(0, presentation.TeamSummaryPresentations[0].NumberOfMembers);
                Assert.AreEqual(Ok, presentation.Status);
            }
        }


        class NotLoggedIn : PresentTeamSummariesUseCaseUnitTests
        {
            [Test]
            public void NotPresented()
            {
                TestFixture.Context.TeamGateway.Save(new Team { Name = "Team A" });
                var presentation = _useCase.PresentTeams();
                Assert.AreEqual(0, presentation.TeamSummaryPresentations.Count());
                Assert.AreEqual(Unauthorized, presentation.Status);
            }
        }

    }
}
