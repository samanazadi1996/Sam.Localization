using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Sam.Localization.WebApi.Infrastructure.LocalizationServicesRegistration
{
    public class LocalizationParameterOperationFilter : IOperationFilter
    {
        private readonly SamLocationOptions options;

        public LocalizationParameterOperationFilter(SamLocationOptions options)
        {
            this.options = options;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= new List<OpenApiParameter>();


            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "accept-language",
                In = ParameterLocation.Header,
                Description = "[ " + string.Join(" or ", options.SupportedCultures) + " ]"
            });
        }
    }
}
