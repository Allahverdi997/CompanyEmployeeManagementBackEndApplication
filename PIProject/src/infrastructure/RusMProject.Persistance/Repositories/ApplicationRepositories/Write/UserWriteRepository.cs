using RusMProject.Domain.Entities;
using RusMProject.Persistance.DbContexts;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Repositories.ApplicationRepositories.Write
{
    public class UserWriteRepository : WriteGenericRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
