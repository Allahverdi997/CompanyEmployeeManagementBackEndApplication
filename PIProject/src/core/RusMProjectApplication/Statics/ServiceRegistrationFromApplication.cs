using AutoMapper;
using JWTService.Concrete;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RusMProjectApplication.Mapping;
using RusMProjectApplication.Mapping.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Statics
{
    public static class ServiceRegistrationFromApplication
    {
        public static IServiceCollection GenerateStartupFromApplication(this IServiceCollection services,IConfiguration configuration)
        {
            var assm = Assembly.GetExecutingAssembly();

            var profiles = assm.GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));

            

            var mappingConfig = new MapperConfiguration(i => 
            {
                foreach (var profile in profiles)
                {
                    i.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddMediatR(assm);
            JWTService.DependencyResolvers.DependencyResolver.JWTConfiguration(services, configuration);

            return services;


        }
    }
}
