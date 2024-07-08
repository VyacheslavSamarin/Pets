using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Pets.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
