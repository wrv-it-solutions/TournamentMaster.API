namespace TournamentMaster.API.Extensions
{
    public static class ConfigureLogging
    {
        public static IServiceCollection AddAppLogging(this IServiceCollection services, IConfiguration config)
        {
            services.AddLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
                logging.AddAWSProvider(config.GetAWSLoggingConfigSection());
            });

            return services;
        }
    }
}
