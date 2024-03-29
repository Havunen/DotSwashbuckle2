﻿using System.Globalization;
using System.IO;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Writers;

namespace DotSwashbuckle.AspNetCore.TestSupport
{
    public static class IOpenApiAnyExtensions
    {
        public static string ToJson(this IOpenApiAny openApiAny)
        {
            var stringWriter = new StringWriter(CultureInfo.InvariantCulture);
            var jsonWriter = new OpenApiJsonWriter(stringWriter);

            openApiAny.Write(jsonWriter,  OpenApiSpecVersion.OpenApi3_0);

            return stringWriter.ToString();
        }
    }
}
