﻿namespace MeChallenge.API.Configuration.Docs
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    /// <summary>
    ///     Represents extension services <see cref="SwaggerExtension" />
    /// </summary>
    internal static class SwaggerExtension
    {
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo {Title = "Me Challenge API V1", Version = "v1"});
            });

            return services;
        }

        internal static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Me Challenge API V1");
            });
        }
    }
}