using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction
{
    public interface IUnitOfWorkAble
    {
        IDepartmentReadRepository DepartmentReadRepository { get; }

        IEmployeeReadRepository EmployeeReadRepository { get; }

        IDepartmentWriteRepository DepartmentWriteRepository { get; }

        IEmployeeWriteRepository EmployeeWriteRepository { get; }
        IUserReadRepository UserReadRepository { get; }
        IUserWriteRepository UserWriteRepository { get; }
    }
}
