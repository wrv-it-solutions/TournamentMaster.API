using Amazon.SecretsManager;
using TournamentMaster.API.Extensions;
using TournamentMaster.Application.DependencyInjection;
using TournamentMaster.Application.Interfaces.AWS;
using TournamentMaster.Infrastructure.AWS;
using TournamentMaster.Infrastructure.DependencyInjection;

namespace TournamentMaster.API
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            
            builder.Services.AddSwaggerGen();

            builder.Services.AddAWSService<IAmazonSecretsManager>();
            builder.Services.AddSingleton<ISecretProvider, AwsSecretProvider>();


            builder.Services.AddSwaggerDocumentation();
            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddAppLogging(builder.Configuration);
            await builder.Services.AddInfrastructureAsync(builder.Configuration);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
