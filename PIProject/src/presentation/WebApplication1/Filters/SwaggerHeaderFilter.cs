using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using RusMProject.WebAPI.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RusMProject.WebAPI.Filters
{
    public class SwaggerHeaderFilter : IOperationFilter
    {
        void IOperationFilter.Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var isDefinedSign = context.MethodInfo.GetCustomAttributes(inherit: true)
                .Any(a => a.GetType().Equals(typeof(SwaggerAuthToken)));

            if (isDefinedSign)
                AddParameter(operation);




        }

        private void AddParameter(OpenApiOperation operation)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "AuthenticationToken",
                In = ParameterLocation.Header,
                Description = "",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString(string.Empty)
                }
            });
        }
    }
}
