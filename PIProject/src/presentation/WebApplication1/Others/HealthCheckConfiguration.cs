using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RusMProject.WebAPI.Others
{
    public static class HealthCheckConfiguration
    {
        public static IApplicationBuilder HealthCheck(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseHealthChecks("/api/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("Layihe Islek Veziyyetdedir");
                }
            });

            return applicationBuilder;
        }
    }
}
