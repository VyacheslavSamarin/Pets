using Pets.Application.Common.Mappings;
using Pets.Application.Interfaces;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


using Pets.Application;
using Pets.Persistence;
using Pets.WebApi.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace Pets.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get;}

        public Startup(IConfiguration configuration) => Configuration = configuration;    

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IPetsDbContext).Assembly));
            });
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddApplication();
            services.AddPersitence(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "dev");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(async endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
