using RusMProject.Domain.Entities;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Services
{
    public class ExceptionNotificationManager : IExceptionNotificationServiceAble
    {
        public IExceptionNotificationReadRepository ExceptionNotificationReadRepository { get; set; }
        public ExceptionNotificationManager(IExceptionNotificationReadRepository exceptionNotificationReadRepository)
        {
            ExceptionNotificationReadRepository = exceptionNotificationReadRepository;
        }
        public ExceptionNotification Get(string name)
        {
           var exception=ExceptionNotificationReadRepository.GetExpAsync(e => e.Name == name).Result;
            return exception;
        }

        public Task<ExceptionNotification> Get(Expression<Func<ExceptionNotification, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExceptionNotification> GetAll()
        {
            var exceptions = ExceptionNotificationReadRepository.GetAll();
            return exceptions;
        }
    }
}
