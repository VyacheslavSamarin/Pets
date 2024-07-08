using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using Pets.Application.Interfaces;

namespace Pets.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersitence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PetsDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddScoped<IPetsDbContext>(provider => provider.GetService<PetsDbContext>());
            return services;
        }
    }
}
