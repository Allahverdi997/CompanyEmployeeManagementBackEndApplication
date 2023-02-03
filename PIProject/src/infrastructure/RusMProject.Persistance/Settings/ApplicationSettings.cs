using Microsoft.Extensions.Configuration;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Settings
{
    public class ApplicationSettings : IApplicationSettingsAble
    {
        public IConfiguration Configuration { get; set; }
        public ApplicationSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string ConnectionString => Configuration.GetConnectionString("Default");
        public string JwtKey => Setting<string>("JWTKey.Key");
        private T Setting<T>(string name)
        {
            string value = Configuration.GetSection(name.Split(".")[0]).GetSection(name.Split(".")[1]).Value;

            if (value!=null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }

            throw new NotFoundException("Value not found");
        }
    }
}
