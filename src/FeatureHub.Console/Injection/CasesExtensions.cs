using FeatureHub.Application.Repositories.DataAccess;
using FeatureHub.Console.UseCases.Monitor;
using FeatureHub.Infrastructure.DataAccess;
using FeatureHub.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureHub.Console.Injection
{
    public static class CasesExtensions
    {
        public static IServiceCollection RegisterCases(this IServiceCollection services)
        {
            services.Add(ServiceDescriptor.Scoped<IFeatureRepository, FeatureRepository>());
            services.Add(ServiceDescriptor.Scoped<IMonitorFeatureUseCase, MonitorFeatureUseCase>());

            var connection = Environment.GetEnvironmentVariable("CONN");

            if (!string.IsNullOrEmpty(connection))
            {
                using Context context = new Context();
                context.Database.Migrate();
            }

            return services;
        }
    }
}
