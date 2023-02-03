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
    public class EmployeeWriteRepository : WriteGenericRepository<Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
