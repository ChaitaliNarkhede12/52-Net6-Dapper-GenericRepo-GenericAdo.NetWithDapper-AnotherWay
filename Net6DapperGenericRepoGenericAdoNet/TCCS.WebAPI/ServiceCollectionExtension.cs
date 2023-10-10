using Microsoft.Extensions.Options;

namespace TCCS.WebAPI
{
    public static class ServiceCollectionExtension
    {
        public static void AddConfiguration<TConfig>(this IServiceCollection services, string configName)
            where TConfig : class, new()
        {
            services.AddOptions<TConfig>()
                .Configure<IConfiguration>((settings, configuration) => {
                    configuration.GetSection(configName).Bind(settings);
                });

            var configInstance = services.BuildServiceProvider().GetService<IOptions<TConfig>>();

            services.AddSingleton(typeof(TConfig), configInstance.Value);
        }
    }
}
