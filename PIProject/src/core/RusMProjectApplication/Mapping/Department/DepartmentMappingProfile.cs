using AutoMapper;
using RusMProjectApplication.Registration.CreateDSO;
using RusMProjectApplication.Registration.UpdateDSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RusMProject.Domain.Entities;
using RusMProjectApplication.ViewModels.Department;

namespace RusMProjectApplication.Mapping.Department
{
    public class DepartmentMappingProfile:Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<RusMProject.Domain.Entities.Department, GetAllDepartmentResponseModel>();
            CreateMap<RusMProject.Domain.Entities.Department, GetDepartmentResponseModel>();


            CreateMap<DepartmentDSO, RusMProject.Domain.Entities.Department>();

            CreateMap<DepartmentUpdateDSO, RusMProject.Domain.Entities.Department>();
        }
    }
}
