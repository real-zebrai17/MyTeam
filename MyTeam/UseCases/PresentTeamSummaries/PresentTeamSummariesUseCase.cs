using MyTeam.Entities;
using System;
using System.Linq;
using static MyTeam.UseCases.UseCaseStatus;

namespace MyTeam.UseCases.PresentTeamSummaries
{
    public class PresentTeamSummariesUseCase : UseCaseResult
    {
        private readonly IContext _context;

        public PresentTeamSummariesUseCase(IContext context)
        {
            _context = context;
        }

        public PresentTeamSummaries PresentTeams()
        {
            var teams = _context.TeamGateway.FindAllTeams();
            var user = _context.GateKeeper.LoggedInUser;
            if (!_context.GateKeeper.IsLoggedIn)
                return new PresentTeamSummaries
                {
                    Status = Unauthorized,
                    Actions = Array.Empty<string>(),
                    TeamSummaryPresentations = Array.Empty<TeamSummaryPresentation>()
                };

            return new PresentTeamSummaries
            {
                Status = Ok,
                Actions = user == null ? new string[0] : GetActionsForRoles(_context.GateKeeper.LoggedInUser.Roles),
                TeamSummaryPresentations 
                        = user == null 
                            ? new TeamSummaryPresentation[0]
                            : teams.Select(c => new TeamSummaryPresentation { Name = c.Name, NumberOfMembers = c.NumberOfMembers })
                                   .ToArray()
            };
        }

        private string[] GetActionsForRoles(UserRoles roles)
        {
            return roles.HasFlag(UserRoles.Admin)
                ? new[] { "Create" }
                : new string[0];
        }
    }
}
