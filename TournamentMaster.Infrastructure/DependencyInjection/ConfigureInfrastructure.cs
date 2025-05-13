using Amazon.SecretsManager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using TournamentMaster.Application.DTOs.AWS;
using TournamentMaster.Application.Interfaces.AWS;
using TournamentMaster.Infrastructure.AWS;
using TournamentMaster.Infrastructure.Database;

namespace TournamentMaster.Infrastructure.DependencyInjection
{
    public static class ConfigureInfrastructure
    {
        public static async Task<IServiceCollection> AddInfrastructureAsync(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAWSService<IAmazonSecretsManager>();
            services.AddSingleton<ISecretProvider, AwsSecretProvider>();

            // Fetch connection string from AWS Secrets Manager
            var tempProvider = services.BuildServiceProvider();
            var secretProvider = tempProvider.GetRequiredService<ISecretProvider>();
            var secretJson = await secretProvider.GetSecretAsync("test/TournamentMasterApp/Postgres");

            var configData = JsonSerializer.Deserialize<RdsSecret>(secretJson);
            var connString = $"Host={configData.Host};Port={configData.Port};Username={configData.Username};Password={configData.Password};Database={configData.DbInstanceIdentifier};";

            services.AddDbContext<TournamentDbContext>(options =>
                options.UseNpgsql(connString));

            return services;
        }
    }
}
