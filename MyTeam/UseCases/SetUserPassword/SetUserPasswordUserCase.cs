using MyTeam.Entities;

namespace MyTeam.UseCases.SetUserPassword
{
    public class SetUserPasswordUserCase
    {
        private readonly IContext _context;

        public SetUserPasswordUserCase(IContext context)
        {
            _context = context;
        }

        public UseCaseResult SetUserPassword(string userName, string password)
        {
            var user = _context.UserGateway.FindByUserName(userName);
            if (_context.GateKeeper.LoggedInUser != null &&
                (_context.GateKeeper.LoggedInUser.Roles.HasFlag(UserRoles.Admin) || _context.GateKeeper.LoggedInUser.SameAs(user)))
            {
                _context.PasswordLocker.Set(user.Id.Value, password);
                return new UseCaseResult { Status = UseCaseStatus.Ok };
            }
            return new UseCaseResult { Status = UseCaseStatus.Unauthorized };
        }
    }
}
