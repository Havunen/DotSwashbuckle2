﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication;

namespace DotSwashbuckle.AspNetCore.SwaggerGen
{
    public class SwaggerGeneratorOptions
    {
        public SwaggerGeneratorOptions()
        {
            SwaggerDocs = new Dictionary<string, OpenApiInfo>(StringComparer.Ordinal);
            DocInclusionPredicate = DefaultDocInclusionPredicate;
            OperationIdSelector = DefaultOperationIdSelector;
            TagsSelector = DefaultTagsSelector;
            SortKeySelector = DefaultSortKeySelector;
            SecuritySchemesSelector = null;
            SchemaComparer = StringComparer.Ordinal;
            Servers = new List<OpenApiServer>();
            SecuritySchemes = new Dictionary<string, OpenApiSecurityScheme>(StringComparer.Ordinal);
            SecurityRequirements = new List<OpenApiSecurityRequirement>();
            ParameterFilters = new List<IParameterFilter>();
            RequestBodyFilters = new List<IRequestBodyFilter>();
            OperationFilters = new List<IOperationFilter>();
            DocumentFilters = new List<IDocumentFilter>();
        }

        public IDictionary<string, OpenApiInfo> SwaggerDocs { get; set; }

        public Func<string, ApiDescription, bool> DocInclusionPredicate { get; set; }

        public bool IgnoreObsoleteActions { get; set; }

        public Func<IEnumerable<ApiDescription>, ApiDescription> ConflictingActionsResolver { get; set; }

        public Func<ApiDescription, string> OperationIdSelector { get; set; }

        public Func<ApiDescription, IList<string>> TagsSelector { get; set; }

        public Func<ApiDescription, string> SortKeySelector { get; set; }

        public bool InferSecuritySchemes { get; set; }

        public Func<IEnumerable<AuthenticationScheme>, IDictionary<string, OpenApiSecurityScheme>> SecuritySchemesSelector { get; set;}

        public bool DescribeAllParametersInCamelCase { get; set; }

        public List<OpenApiServer> Servers { get; set; }

        public IDictionary<string, OpenApiSecurityScheme> SecuritySchemes { get; set; }

        public IList<OpenApiSecurityRequirement> SecurityRequirements { get; set; }

        public IComparer<string> SchemaComparer { get; set; }

        public IList<IParameterFilter> ParameterFilters { get; set; }

        public List<IRequestBodyFilter> RequestBodyFilters { get; set; }

        public List<IOperationFilter> OperationFilters { get; set; }

        public IList<IDocumentFilter> DocumentFilters { get; set; }

        private bool DefaultDocInclusionPredicate(string documentName, ApiDescription apiDescription)
        {
            return apiDescription.GroupName == null || apiDescription.GroupName == documentName;
        }

        private string DefaultOperationIdSelector(ApiDescription apiDescription)
        {
            var actionDescriptor = apiDescription.ActionDescriptor;

            // Resolve the operation ID from the route name and fallback to the
            // endpoint name if no route name is available. This allows us to
            // generate operation IDs for endpoints that are defined using
            // minimal APIs.
            return
                actionDescriptor.AttributeRouteInfo?.Name
                ?? (actionDescriptor.EndpointMetadata?.LastOrDefault(m => m is IEndpointNameMetadata) as IEndpointNameMetadata)?.EndpointName;
        }

        private IList<string> DefaultTagsSelector(ApiDescription apiDescription)
        {
            var actionDescriptor = apiDescription.ActionDescriptor;
            var tagsMetadata = actionDescriptor.EndpointMetadata?.LastOrDefault(m => m is ITagsMetadata) as ITagsMetadata;
            if (tagsMetadata != null)
            {
                return new List<string>(tagsMetadata.Tags);
            }

            if (apiDescription.ActionDescriptor.RouteValues.TryGetValue("controller", out var controller))
            {
                return new[] { controller };
            }

            return Array.Empty<string>();
        }

        private string DefaultSortKeySelector(ApiDescription apiDescription)
        {
            return TagsSelector(apiDescription).First();
        }
    }
}
