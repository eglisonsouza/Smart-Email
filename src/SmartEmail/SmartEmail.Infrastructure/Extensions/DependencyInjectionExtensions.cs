using Microsoft.Extensions.DependencyInjection;
using SmartEmail.Core.Services;
using SmartEmail.Infrastructure.Services;

namespace SmartEmail.Infrastructure.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ISmtpService, SmtpService>();
            services.AddTransient<ISendEmailService, SendEmailService>();
            return services;
        }
    }
}
