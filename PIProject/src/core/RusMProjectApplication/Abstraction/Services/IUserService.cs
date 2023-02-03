using RusMProject.Domain.Entities;
using RusMProjectApplication.Models.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Services
{
    public interface IUserService
    {
        string GenerateToken(User user);
    }
}
