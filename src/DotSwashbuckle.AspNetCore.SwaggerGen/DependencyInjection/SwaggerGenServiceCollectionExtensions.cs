﻿using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ApiDescriptions;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using DotSwashbuckle.AspNetCore.Swagger;
using DotSwashbuckle.AspNetCore.SwaggerGen;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for configuring Swagger generation on <see cref="IServiceCollection" />.
    /// </summary>
    public static class SwaggerGenServiceCollectionExtensions
    {
        /// <summary>
        /// Add services required by the Swagger generation middleware.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="setupAction">A lambda that configures Swagger generation options.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static IServiceCollection AddSwaggerGen(
            this IServiceCollection services,
            Action<SwaggerGenOptions> setupAction = null)
        {
            // Add Mvc convention to ensure ApiExplorer is enabled for all actions
            services.Configure<MvcOptions>(c =>
                c.Conventions.Add(new SwaggerApplicationConvention()));

            // Register custom configurators that takes values from SwaggerGenOptions (i.e. high level config)
            // and applies them to SwaggerGeneratorOptions and SchemaGeneratorOptoins (i.e. lower-level config)
            services.AddTransient<IConfigureOptions<SwaggerGeneratorOptions>, ConfigureSwaggerGeneratorOptions>();
            services.AddTransient<IConfigureOptions<SchemaGeneratorOptions>, ConfigureSchemaGeneratorOptions>();

            // Register generator and it's dependencies
            services.TryAddTransient<ISwaggerProvider, SwaggerGenerator>();
            services.TryAddTransient<IAsyncSwaggerProvider, SwaggerGenerator>();
            services.TryAddTransient(s => s.GetRequiredService<IOptions<SwaggerGeneratorOptions>>().Value);
            services.TryAddTransient<ISchemaGenerator, SchemaGenerator>();
            services.TryAddTransient(s => s.GetRequiredService<IOptions<SchemaGeneratorOptions>>().Value);
            services.TryAddTransient<ISerializerDataContractResolver>(s =>
            {
                var serializerOptions = s.GetService<IOptions<JsonOptions>>()?.Value?.JsonSerializerOptions
                    ?? new JsonSerializerOptions();

                return new JsonSerializerDataContractResolver(serializerOptions);
            });

            // Used by the <c>dotnet-getdocument</c> tool from the Microsoft.Extensions.ApiDescription.Server package.
            services.TryAddSingleton<IDocumentProvider, DocumentProvider>();

            if (setupAction != null) services.ConfigureSwaggerGen(setupAction);

            return services;
        }

        /// <summary>
        /// Configure options for Swagger generation.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <param name="setupAction">A lambda that configures Swagger generation options.</param>
        /// <returns>The <see cref="IServiceCollection" />.</returns>
        public static void ConfigureSwaggerGen(
            this IServiceCollection services,
            Action<SwaggerGenOptions> setupAction)
        {
            services.Configure(setupAction);
        }
    }
}
