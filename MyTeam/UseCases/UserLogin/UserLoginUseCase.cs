using static MyTeam.UseCases.UseCaseStatus;

namespace MyTeam.UseCases.UserLogin
{
    public class UserLoginUseCase
    {
        private IContext _context;
        public UserLoginUseCase(IContext context)
        {
            _context = context;
        }
        public LoginResult Login(string userName, string password)
        {
            var user = _context.UserGateway.FindByUserName(userName);
            if (user != null && _context.PasswordLocker.Verify(user.Id.Value, password))
                return new LoginResult { Status = Ok, User = user };

            return new LoginResult { Status = UseCaseStatus.Unauthorized };
        }
    }
}
