using Amazon.SecretsManager;
using Microsoft.Extensions.Configuration;
using TournamentMaster.API.Extensions;
using TournamentMaster.Application.DependencyInjection;
using TournamentMaster.Application.Interfaces.AWS;
using TournamentMaster.Application.Settings;
using TournamentMaster.Infrastructure.AWS;
using TournamentMaster.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            // Bind settings
            var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
            builder.Services.AddSingleton(jwtSettings);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
