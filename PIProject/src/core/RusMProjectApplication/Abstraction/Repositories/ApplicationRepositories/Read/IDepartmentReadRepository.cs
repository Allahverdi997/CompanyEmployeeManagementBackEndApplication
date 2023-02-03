using RusMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read
{
    public interface IDepartmentReadRepository : IReadGenericRepository<Department>
    {
        List<Department> GetAllDepartments();
        List<Department> SearchDepartments(string word);
        List<Department> GetDepartmentsWithPage(int page, int value);
    }
}
