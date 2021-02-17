using Microsoft.AspNetCore.Mvc;
using MyTeam;
using MyTeam.Entities;
using MyTeam.UseCases.PresentTeamSummaries;

namespace MyTeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IContext _context;

        public TeamsController(IContext context)
        {
            _context = context;
        }


        [HttpGet]
        public PresentTeamSummaries Teams()
        {
            var bob = new User("Bob");
            bob.AddRole(UserRoles.Admin);
            _context.GateKeeper.SetLoggedIn(bob);
            _context.TeamGateway.Save(new Team { Name = "Store" });

            var _useCase = new PresentTeamSummariesUseCase(_context);
            var presentation = _useCase.PresentTeams();
            if (presentation.Status == MyTeam.UseCases.UseCaseStatus.Unauthorized)
                Unauthorized();

            return presentation;
        }
    }
}
