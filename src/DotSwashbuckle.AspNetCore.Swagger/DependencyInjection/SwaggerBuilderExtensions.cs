﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using DotSwashbuckle.AspNetCore.Swagger;

namespace Microsoft.AspNetCore.Builder
{
    public static class SwaggerBuilderExtensions
    {
        /// <summary>
        /// Register the Swagger middleware with provided options
        /// </summary>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, SwaggerOptions options)
        {
            return app.UseMiddleware<SwaggerMiddleware>(options);
        }

        /// <summary>
        /// Register the Swagger middleware with optional setup action for DI-injected options
        /// </summary>
        public static IApplicationBuilder UseSwagger(
            this IApplicationBuilder app,
            Action<SwaggerOptions> setupAction = null)
        {
            SwaggerOptions options;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<SwaggerOptions>>().Value;
                setupAction?.Invoke(options);
            }

            return app.UseSwagger(options);
        }

        public static IEndpointConventionBuilder MapSwagger(
            this IEndpointRouteBuilder endpoints,
            string pattern = "/swagger/{documentName}/swagger.{json|yaml}",
            Action<SwaggerEndpointOptions> setupAction = null)
        {
            if (RoutePatternFactory.Parse(pattern).Parameters.All(x => !string.Equals(x.Name, "documentName", StringComparison.Ordinal)))
            {
                throw new ArgumentException("Pattern must contain '{documentName}' parameter", nameof(pattern));
            }

            void EndpointSetupAction(SwaggerOptions options)
            {
                var endpointOptions = new SwaggerEndpointOptions();

                setupAction?.Invoke(endpointOptions);

                options.RouteTemplate = pattern;
                options.SerializeAsV2 = endpointOptions.SerializeAsV2;
                options.PreSerializeFilters.AddRange(endpointOptions.PreSerializeFilters);
            }

            var pipeline = endpoints.CreateApplicationBuilder()
                .UseSwagger(EndpointSetupAction)
                .Build();

            return endpoints.MapGet(pattern, pipeline);
        }
    }
}