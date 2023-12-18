using Microsoft.Extensions.DependencyInjection;
using SmartEmail.Application.Consumers;

namespace SmartEmail.Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddHostedService<EmailConsumer>();
            return services;
        }
    }
}
