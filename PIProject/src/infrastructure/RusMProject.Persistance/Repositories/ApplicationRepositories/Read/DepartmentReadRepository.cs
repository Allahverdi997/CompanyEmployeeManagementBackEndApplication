using MediatR;
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
    public class DepartmentReadRepository:ReadGenericRepository<Department>,IDepartmentReadRepository
    {
        public DepartmentReadRepository(AppDbContext appDbContext):base(appDbContext)
        {

        }

        public List<Department> GetAllDepartments()
        {
            return GetAll().ToList();
        }

        public List<Department> SearchDepartments(string word)
        {
            return GetAll().Where(x=>x.Name.Contains(word)).ToList();
        }

        public List<Department> GetDepartmentsWithPage(int page, int value)
        {
            var model = GetAll();
            if (page == 1 || page == 0)
            {
                model = model.Take(value);
            }
            else
            {
                model = model.Skip((page - 1) * value).Take(value);
            }
            return model.ToList();
        }
    }
}
