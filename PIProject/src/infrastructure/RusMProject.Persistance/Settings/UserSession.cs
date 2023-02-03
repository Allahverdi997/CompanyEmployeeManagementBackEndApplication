using RusMProject.Domain.Entities;
using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Settings
{
    public class UserSession:IUserSessionAble
    {
        public string SecretKey { get; set; }
        public string AuthToken { get ; set ; }
        public User User { get; set; }
    }
}
