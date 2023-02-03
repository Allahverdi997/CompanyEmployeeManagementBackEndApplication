using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeeReadRepository : ReadGenericRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public List<Employee> GetAllEmployees()
        {
            return GetEmployeesWithInclude().ToList();
        }

        public List<Employee> SearchEmployees(string word)
        {
            return GetEmployeesWithInclude().Where(x=>x.Name.Contains(word)).ToList();
        }

        public List<Employee> GetEmployeesWithDepartment(int depId)
        {
            return GetEmployeesWithInclude().Where(x => x.DepartmentId == depId).ToList();
        }

        public IQueryable<Employee> GetEmployeesWithInclude()
        {
            return GetAll().Include(x => x.Department);
        }

        public List<Employee> GetEmployeesWithPage(int page, int value)
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

        public Employee GetEmployeeWithInclude(int id)
        {
            return Table.Where(x => x.Id == id).Include(x => x.Department).FirstOrDefault();
        }
    }
}
