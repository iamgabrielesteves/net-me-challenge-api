namespace MeChallenge.API
{
    using Configuration;
    using Configuration.Docs;
    using Configuration.ProblemDetails;
    using Hellang.Middleware.ProblemDetails;
    using Infrastructure;
    using Infrastructure.Database;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Newtonsoft.Json;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    opt.SerializerSettings.Converters = new JsonConverter[] {new TrimmingJsonConverter()};
                });

            services
                .AddVersioningSystem()
                .AddSwaggerDocumentation()
                .AddProblemDetailsMiddleware()
                .AddHealthChecks();

            return ApplicationStartup.Initialize(
                services,
                Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MeChallengeContext dataContext)
        {
            app.UseProblemDetails();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthcheck",
                    new HealthCheckOptions
                    {
                        ResultStatusCodes =
                        {
                            [HealthStatus.Healthy] = StatusCodes.Status200OK,
                            [HealthStatus.Degraded] = StatusCodes.Status200OK,
                            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                        }
                    });
            });

            app.UseSwaggerDocumentation();

            dataContext.Database.Migrate();
        }
    }
}