using Microsoft.AspNetCore.Mvc;
using MyTeam;
using MyTeam.UseCases.SetUserPassword;
using MyTeam.UseCases.UserLogin;
using MyTeam.UseCases;

namespace MyTeamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IContext _context;

        public AccountController(IContext context)
        {
            _context = context;
        }

        [HttpPost("SetPassword")]
        public void SetPassword(string userName, string password)
        {
            var useCase = new SetUserPasswordUserCase(_context);
            var result = useCase.SetUserPassword(userName, password);
            if (result.Status == MyTeam.UseCases.UseCaseStatus.Unauthorized)
                Unauthorized();

            Ok();
        }

        [HttpPost("/Login")]
        public void Login(string userName, string password)
        {
            var useCase = new UserLoginUseCase(_context);
            var result = useCase.Login(userName, password);
            if (result.Status == UseCaseStatus.Unauthorized)
                Unauthorized();

            Ok();
        }
    }
}
