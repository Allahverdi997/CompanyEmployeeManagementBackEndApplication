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
    public class ExceptionNotificationReadRepository : ReadGenericRepository<ExceptionNotification>, IExceptionNotificationReadRepository
    {
        public ExceptionNotificationReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
