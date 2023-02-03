using Microsoft.EntityFrameworkCore;
using RusMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Repositories
{
    public interface IReadGenericRepository<T>:IRepositoryAble<T> where T:class,IEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);

        IQueryable<T> GetAllData(Expression<Func<T, bool>> predicate);
        Task<T> GetExpAsync(Expression<Func<T, bool>> predicate);
    }
}
