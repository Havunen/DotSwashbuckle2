﻿using Microsoft.OpenApi.Models;
using DotSwashbuckle.AspNetCore.SwaggerGen;

namespace DotSwashbuckle.AspNetCore.Newtonsoft.Test
{
    public class RecursiveCallSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (model.Type == "object")
            {
                model.Properties.Add("Self", context.SchemaGenerator.GenerateSchema(context.Type, context.SchemaRepository));
            }
        }
    }
}
