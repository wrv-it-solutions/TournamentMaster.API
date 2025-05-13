using Microsoft.Extensions.DependencyInjection;

namespace TournamentMaster.Application.DependencyInjection
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Example: register MediatR, AutoMapper, FluentValidation, etc.
            // services.AddMediatR(typeof(SomeHandler).Assembly);
            // services.AddAutoMapper(...);

            return services;
        }
    }
}
