using FeatureHub.Console.UseCases.Sum;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureHub.Console.Injection
{
    public static class CasesExtensions
    {
        public static IServiceCollection RegisterCases(this IServiceCollection services)
        {
            services.Add(ServiceDescriptor.Scoped<ISumUseCase, SumUseCase>());

            return services;
        }
    }
}
