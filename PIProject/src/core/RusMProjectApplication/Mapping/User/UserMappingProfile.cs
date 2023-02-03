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
using RusMProjectApplication.Models.Domain.User;

namespace RusMProjectApplication.Mapping.Employee
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RusMProject.Domain.Entities.User, GetLoginUserResponseModel>();
            CreateMap<UserDSO, User>();
        }
    }
}
