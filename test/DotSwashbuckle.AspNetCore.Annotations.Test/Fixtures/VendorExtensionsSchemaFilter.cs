﻿using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.SwaggerGen;

namespace DotSwashbuckle.AspNetCore.Annotations.Test
{
    public class VendorExtensionsSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Extensions.Add("X-property1", new OpenApiString("value"));
        }
    }
}