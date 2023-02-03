using Microsoft.EntityFrameworkCore;
using RusMProject.Domain.Common;
using RusMProject.Persistance.DbContexts;
using RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Transaction;
using RusMProjectApplication.Abstraction.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RusMProject.Persistance.Statics;
using RusMProject.Domain.Entities;
using RusMProject.Persistance.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using System.Security.Claims;
using JWTService.Abstract;

namespace RusMProject.Persistance.Repositories
{
    public class WriteGenericRepository<T> : IWriteGenericRepository<T> where T : BaseEntity, IEntity
    {
        public AppDbContext Context { get; set; }
        public IJWTService JWTService { get; set; }
        public IUserReadRepository UserReadRepository { get; set; }
        public WriteGenericRepository(AppDbContext context)
        {
            Context = context;
        }
        public DbSet<T> Table => Context.Set<T>();

        public async Task<bool> Add(T model, User user)
        {
            var entityEntry = await Table.AddAsync(model);
            Commit(user);
            return true;
        }

        public async Task AddRange(List<T> models, User user)
        {
            await Table.AddRangeAsync(models);
            Commit(user);
        }

        public bool Remove(T model, User user)
        {
            var entityEntry = Table.Remove(model);
            Commit(user);
            return true;
        }

        public void RemoveRange(List<T> models, User user)
        {
            Table.RemoveRange(models);
            Commit(user);
        }

        public async void Commit(User user = null)
        {
            var entitiesEntryTracker = Context.ChangeTracker.Entries();

            foreach (var entityEntry in entitiesEntryTracker)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    if (user != null)
                        entityEntry.Property("CreatorUserId").CurrentValue = user.Id;
                    else
                        entityEntry.Property("CreatorUserId").CurrentValue = 1;

                    entityEntry.Property("CreatorDate").CurrentValue = DateTime.UtcNow;

                    entityEntry.Property("IsActive").CurrentValue = true;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    if (user != null)
                        entityEntry.Property("EditorUserId").CurrentValue = user.Id;
                    else
                        entityEntry.Property("EditorUserId").CurrentValue = 1;

                    entityEntry.Property("EditorUserId").IsModified = true;
                    entityEntry.Property("EditorDate").CurrentValue = DateTime.UtcNow;
                    entityEntry.Property("EditorDate").IsModified = true;

                    entityEntry.Property("CreatorUserId").IsModified = false;
                    entityEntry.Property("CreatorDate").IsModified = false;

                    entityEntry.Property("IsActive").IsModified = false;
                }
            }
            Context.SaveChanges();
            Context.ChangeTracker.Clear();
        }
        public bool Update(T model, User user)
        {
            Table.Update(model);
            Commit(user);
            return true;
        }
    }
}
