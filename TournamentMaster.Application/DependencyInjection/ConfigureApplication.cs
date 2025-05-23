﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TournamentMaster.Application.Interfaces.UseCases;
using TournamentMaster.Application.Settings;
using TournamentMaster.Application.UseCases;

namespace TournamentMaster.Application.DependencyInjection
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {




            services.AddScoped<IBasicSignUpUseCase, BasicSignUpUseCase>();

            return services;
        }
    }
}
