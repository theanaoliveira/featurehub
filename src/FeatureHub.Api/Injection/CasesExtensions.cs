using FeatureHub.Application.UseCases.Sum;
using FeatureHub.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace FeatureHub.Api.Injection
{
    public static class CasesExtensions
    {
        public static IServiceCollection RegisterCases(this IServiceCollection services)
        {
            services.Add(ServiceDescriptor.Scoped<ISumUseCase, SumUseCase>());

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
