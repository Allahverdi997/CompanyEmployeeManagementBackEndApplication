using Microsoft.EntityFrameworkCore;
using RusMProject.Domain.Common;
using RusMProject.Persistance.DbContexts;
using RusMProjectApplication.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Repositories
{
    public class ReadGenericRepository<T> : IReadGenericRepository<T> where T : BaseEntity, IEntity
    {
        public AppDbContext Context { get; set; }
        public ReadGenericRepository(AppDbContext context)
        {
            Context = context;
        }
        public DbSet<T> Table => Context.Set<T>();
        public IQueryable<T> GetAll()
        {
            return Table;
        }

        public IQueryable<T> GetAllData(Expression<Func<T, bool>> predicate)
        {
            return Table.Where(predicate);

        }

        public async Task<T> GetAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<T> GetExpAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }
    }
}
