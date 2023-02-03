using RusMProject.Domain.Entities;
using RusMProject.Persistance.DbContexts;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Repositories.ApplicationRepositories.Read
{
    public class UserReadRepository : ReadGenericRepository<User>, IUserReadRepository
    {
        public UserReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public User GetUserByNamePassword(string username, string password)
        {
            return Table.AsQueryable().FirstOrDefault(x=>x.Name==username && x.Password==password);
        }
    }
}
