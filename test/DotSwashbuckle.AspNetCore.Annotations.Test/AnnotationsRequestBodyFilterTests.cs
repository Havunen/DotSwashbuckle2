﻿using System.Reflection;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using DotSwashbuckle.AspNetCore.TestSupport;
using Xunit;

namespace DotSwashbuckle.AspNetCore.Annotations.Test
{
    public class AnnotationsRequestBodyFilterTests
    {
        [Fact]
        public void Apply_EnrichesRequestBodyMetadata_IfControllerParameterDecoratedWithSwaggerRequestBodyAttribute()
        {
            var requestBody = new OpenApiRequestBody();
            var parameterInfo = typeof(FakeControllerWithSwaggerAnnotations)
                .GetMethod(nameof(FakeControllerWithSwaggerAnnotations.ActionWithSwaggerRequestBodyAttribute))
                .GetParameters()[0];
            var bodyParameterDescription = new ApiParameterDescription
            {
                ParameterDescriptor = new ControllerParameterDescriptor { ParameterInfo = parameterInfo }
            };
            var context = new RequestBodyFilterContext(bodyParameterDescription, null, null, null);

            Subject().Apply(requestBody, context);

            Assert.Equal("Description for param", requestBody.Description);
            Assert.True(requestBody.Required);
        }

        [Fact]
        public void Apply_EnrichesRequestBodyMetadata_IfEndpointParameterDecoratedWithSwaggerRequestBodyAttribute()
        {
            var requestBody = new OpenApiRequestBody();
            var parameterInfo = typeof(FakeControllerWithSwaggerAnnotations)
                .GetMethod(nameof(FakeControllerWithSwaggerAnnotations.ActionWithSwaggerRequestBodyAttribute))
                .GetParameters()[0];
            var bodyParameterDescription = new ApiParameterDescription
            {
                ParameterDescriptor = new CustomParameterDescriptor { ParameterInfo = parameterInfo }
            };
            var context = new RequestBodyFilterContext(bodyParameterDescription, null, null, null);

            Subject().Apply(requestBody, context);

            Assert.Equal("Description for param", requestBody.Description);
            Assert.True(requestBody.Required);
        }

        [Fact]
        public void Apply_EnrichesParameterMetadata_IfPropertyDecoratedWithSwaggerRequestBodyAttribute()
        {
            var requestBody = new OpenApiRequestBody();
            var modelMetaData = ModelMetadataFactory.CreateForProperty(typeof(SwaggerAnnotatedType),
                nameof(SwaggerAnnotatedType.StringWithSwaggerRequestBodyAttribute));
            var bodyParameterDescription = new ApiParameterDescription
            {
                ModelMetadata = modelMetaData,
                Type = modelMetaData.ModelType,
            };
            var context = new RequestBodyFilterContext(bodyParameterDescription, null, null, null);

            Subject().Apply(requestBody, context);
            
            Assert.Equal("Description for StringWithSwaggerRequestBodyAttribute", requestBody.Description);
            Assert.True(requestBody.Required);
        }

        [Fact]
        public void Apply_DoesNotModifyTheRequiredFlag_IfNotSpecifiedWithSwaggerParameterAttribute()
        {

            var requestBody = new OpenApiRequestBody { Required = true };
            var parameterInfo = typeof(FakeControllerWithSwaggerAnnotations)
                .GetMethod(nameof(FakeControllerWithSwaggerAnnotations.ActionWithSwaggerRequestbodyAttributeDescriptionOnly))
                .GetParameters()[0];
            var bodyParameterDescription = new ApiParameterDescription
            {
                ParameterDescriptor = new ControllerParameterDescriptor { ParameterInfo = parameterInfo }
            };
            var context = new RequestBodyFilterContext(bodyParameterDescription, null, null, null);

            Subject().Apply(requestBody, context);

            Assert.True(requestBody.Required);
        }

        private AnnotationsRequestBodyFilter Subject()
        {
            return new AnnotationsRequestBodyFilter();
        }

        private sealed class CustomParameterDescriptor : ParameterDescriptor, IParameterInfoParameterDescriptor
        {
            public ParameterInfo ParameterInfo { get; set; }
        }
    }
}
