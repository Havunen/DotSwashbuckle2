using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace DotSwashbuckle.AspNetCore.Swagger
{
    public interface IAsyncSwaggerProvider
    {
        Task<OpenApiDocument> GetSwaggerAsync(
            string documentName,
            string host = null,
            string basePath = null);
    }
}