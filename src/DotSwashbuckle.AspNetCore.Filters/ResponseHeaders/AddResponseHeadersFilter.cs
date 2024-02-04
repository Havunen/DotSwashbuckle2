using DotSwashbuckle.AspNetCore.Filters.Extensions;
using DotSwashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DotSwashbuckle.AspNetCore.Filters
{
    public class AddResponseHeadersFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionAttributes = context.GetControllerAndActionAttributes<SwaggerResponseHeaderAttribute>();

            foreach (var attr in actionAttributes)
            {
                foreach (var statusCode in attr.StatusCodes)
                {
                    var response = operation.Responses.FirstOrDefault(x => x.Key == statusCode.ToString(CultureInfo.InvariantCulture)).Value;

                    if (response != null)
                    {
                        if (response.Headers == null)
                        {
                            response.Headers = new Dictionary<string, OpenApiHeader>();
                        }

                        response.Headers.Add(attr.Name, new OpenApiHeader { Description = attr.Description, Schema = new OpenApiSchema { Description = attr.Description, Type = attr.Type, Format = attr.Format } });
                    }
                }
            }
        }
    }
}
