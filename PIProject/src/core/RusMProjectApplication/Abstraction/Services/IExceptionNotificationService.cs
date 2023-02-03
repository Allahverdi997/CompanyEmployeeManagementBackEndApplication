using RusMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Services
{
    public interface IExceptionNotificationServiceAble
    {
        IQueryable<ExceptionNotification> GetAll();
        ExceptionNotification Get(string name);
        Task<ExceptionNotification> Get(Expression<Func<ExceptionNotification,bool>> expression);
    }
}
