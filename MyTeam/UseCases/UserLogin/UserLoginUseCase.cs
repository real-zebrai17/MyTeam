using static MyTeam.UseCases.UseCaseStatus;

namespace MyTeam.UseCases.UserLogin
{
    public class UserLoginUseCase
    {
        public LoginResult Login(string userName, string password)
        {
            return new LoginResult { Status = UseCaseStatus.Unauthorized };
        }
    }
}
