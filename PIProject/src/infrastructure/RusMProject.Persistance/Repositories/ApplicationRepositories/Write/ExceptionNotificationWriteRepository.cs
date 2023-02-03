using RusMProject.Domain.Entities;
using RusMProject.Persistance.DbContexts;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Repositories.ApplicationRepositories.Write
{
    public class ExceptionNotificationWriteRepository : WriteGenericRepository<ExceptionNotification>, IExceptionNotificationWriteRepository
    {
        public ExceptionNotificationWriteRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
