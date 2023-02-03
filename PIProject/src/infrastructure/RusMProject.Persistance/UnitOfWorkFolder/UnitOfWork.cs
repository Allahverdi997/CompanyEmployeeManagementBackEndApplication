using Microsoft.EntityFrameworkCore;
using RusMProject.Persistance.DbContexts;
using RusMProject.Persistance.Repositories.ApplicationRepositories.Read;
using RusMProject.Persistance.Repositories.ApplicationRepositories.Write;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.UnitOfWorkFolder
{
    public class UnitOfWork : IUnitOfWorkAble
    {
        public AppDbContext Context { get; set; }
        public UnitOfWork(AppDbContext context)
        {
            Context = context;
        }
        public IDepartmentReadRepository departmentReadRepository { get; set; }
        public IDepartmentReadRepository DepartmentReadRepository 
        { 
            get 
            {
                return departmentReadRepository ?? new DepartmentReadRepository(Context);
            } 
        }
        public IEmployeeReadRepository employeeReadRepository { get; set; }
        public IEmployeeReadRepository EmployeeReadRepository
        {
            get
            {
                return employeeReadRepository  ?? new EmployeeReadRepository(Context);
            }
        }
        public IDepartmentWriteRepository departmentWriteRepository { get; set; }
        public IDepartmentWriteRepository DepartmentWriteRepository
        {
            get
            {
               return departmentWriteRepository ?? new DepartmentWriteRepository(Context);
            }
        }
        public IEmployeeWriteRepository employeeWriteRepository { get; set; }
        public IEmployeeWriteRepository EmployeeWriteRepository
        {
            get
            {
                return employeeWriteRepository == null ? new EmployeeWriteRepository(Context) : EmployeeWriteRepository;
            }
        }
        public IUserReadRepository userReadRepository { get; set; }
        public IUserReadRepository UserReadRepository 
        {
            get
            {
                return userReadRepository == null ? new UserReadRepository(Context) : UserReadRepository;
            }
        }
        public IUserWriteRepository userWriteRepository { get; set; }
        public IUserWriteRepository UserWriteRepository
        {
            get
            {
                return userWriteRepository == null ? new UserWriteRepository(Context) : UserWriteRepository;
            }
        }
    }
}
