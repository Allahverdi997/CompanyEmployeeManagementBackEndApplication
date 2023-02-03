using Microsoft.EntityFrameworkCore;
using RusMProject.Domain.Common;
using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.AutoTransactionsEnabled = false;
        }
        private readonly Dictionary<Type, object> _dbSets;

        public AppDbContext(DbContextOptions options):base(options)
        {
            _dbSets = new Dictionary<Type, object>();
        }
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity:class,IEntity
        {
            if (_dbSets.Keys.Contains(typeof(TEntity)))
                return _dbSets[typeof(TEntity)] as DbSet<TEntity>;

            var dbSet = this.Set<TEntity>();

            _dbSets.Add(typeof(TEntity), dbSet);

            return dbSet;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), x =>!x.IsInterface && !x.IsAbstract && typeof(IEntityConfigurationAble).IsAssignableFrom(x));
        }
    }
}
