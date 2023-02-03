using AutoMapper;
using RusMProjectApplication.DTOs;
using RusMProjectApplication.Registration.CreateDSO;
using RusMProjectApplication.Registration.UpdateDSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RusMProject.Domain.Entities;
using RusMProjectApplication.ViewModels.Employee;

namespace RusMProjectApplication.Mapping.Employee
{
    public class EmployeeMappingProfile:Profile
    {
        public EmployeeMappingProfile()
        {
            
            CreateMap<RusMProject.Domain.Entities.Employee, EmployeeDTO>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name));

            CreateMap<RusMProject.Domain.Entities.Employee, GetEmployeeResponseModel>()
                .ForMember(x => x.DepartmentName, y => y.MapFrom(z => z.Department.Name));

            CreateMap<RusMProject.Domain.Entities.Employee, GetAllEmployeeResponseModel>();

            CreateMap<EmployeeDSO, RusMProject.Domain.Entities.Employee>();
            CreateMap<EmployeeUpdateDSO, RusMProject.Domain.Entities.Employee>();
        }
    }
}
