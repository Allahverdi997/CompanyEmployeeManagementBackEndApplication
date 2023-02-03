using RusMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read
{
    public interface IUserReadRepository : IReadGenericRepository<User>
    {
        User GetUserByNamePassword(string username,string password);  
    }
}
