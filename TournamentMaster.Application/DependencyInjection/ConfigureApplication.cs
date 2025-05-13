using Microsoft.Extensions.DependencyInjection;
using TournamentMaster.Application.Interfaces.UseCases;
using TournamentMaster.Application.UseCases;

namespace TournamentMaster.Application.DependencyInjection
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Example: register MediatR, AutoMapper, FluentValidation, etc.
            // services.AddMediatR(typeof(SomeHandler).Assembly);
            // services.AddAutoMapper(...);
            services.AddScoped<IBasicSignUpUseCase, BasicSignUpUseCase>();

            return services;
        }
    }
}
