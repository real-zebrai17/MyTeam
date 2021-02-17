using Microsoft.Extensions.DependencyInjection;
using MyTeam.GateKeeperService;
using MyTeam.Gateways;
using MyTeam.PasswordLockerService;
using MyTeam.TestUtilities.Gateways;

namespace MyTeam.TestUtilities
{
    public static class ServiceRegistration
    {
        public static void AddInMemoryGateways(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IUserGateway, InMemoryUserGateway>();
            serviceCollection.AddSingleton<ITeamGateway, InMemoryTeamGateway>();
            serviceCollection.AddSingleton<IPasswordGateway, InMemoryPasswordGateway>();
        }

        public static void AddContext(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IContext, Context>();
            serviceCollection.AddScoped<IGateKeeper, GateKeeper>();
            serviceCollection.AddScoped<IPasswordLocker, PasswordLocker>();
        }
    }
}
