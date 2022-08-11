using FeatureHubSDK;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FeatureHub.Console.Injection
{
    public static class HubExtensions
    {
        public static IServiceCollection ConfigHub(this IServiceCollection services)
        {
            var url = Environment.GetEnvironmentVariable("HUB_URL");
            var apiKey = Environment.GetEnvironmentVariable("HUB_API_KEY");
            var config = new EdgeFeatureHubConfig(url, apiKey);

            services.Add(ServiceDescriptor.Singleton(typeof(IFeatureHubConfig), config));

            config.Init();

            System.Console.WriteLine($"Server evaluated {config.ServerEvaluation}");

            return services;
        }
    }
}
