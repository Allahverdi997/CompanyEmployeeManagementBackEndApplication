using RusMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read
{
    public interface IEmployeeReadRepository: IReadGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesWithInclude();
        List<Employee> SearchEmployees(string word);
        Employee GetEmployeeWithInclude(int id);
        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeesWithPage(int page, int value);
        List<Employee> GetEmployeesWithDepartment(int depId);
    }
}
