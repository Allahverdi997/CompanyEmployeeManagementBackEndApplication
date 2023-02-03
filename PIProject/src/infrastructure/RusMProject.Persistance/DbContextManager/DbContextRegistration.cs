using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RusMProject.Persistance.DbContexts;
using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.DbContextManager
{
    public static class DbContextRegistration
    {
        public static IServiceCollection GenerateFromPersistance(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("RusMProject.Persistance"));
                options.EnableSensitiveDataLogging();
            },ServiceLifetime.Transient);

            return services;
        }
    }
}
