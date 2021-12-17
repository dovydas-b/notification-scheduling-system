using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSS.Commands.Extensions;
using NSS.Infrastructure.Providers;
using NSS.Repository.Context;
using NSS.Repository.Extensions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace notification_scheduling_system
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<NotificationSchedulingDbContext>(options =>
                {
                    var currentAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;

                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        x => x.MigrationsAssembly(currentAssemblyName));
                })
                .AddCommands()
                .AddProviders()
                .AddRepositories()
                .AddSwaggerGen()
                .AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NotificationSchedulingDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}