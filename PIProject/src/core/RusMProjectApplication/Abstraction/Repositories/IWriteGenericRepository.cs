using RusMProject.Domain.Common;
using RusMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Repositories
{
    public interface IWriteGenericRepository<T> : IRepositoryAble<T> where T : class, IEntity
    {
        Task<bool> Add(T model, User user);
        Task AddRange(List<T> models, User user);

        bool Remove(T model, User user);
        void RemoveRange(List<T> models, User user);

        public bool Update(T model, User user);

        void Commit(User user);
    }
}
