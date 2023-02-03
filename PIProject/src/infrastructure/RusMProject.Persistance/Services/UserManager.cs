using AutoMapper;
using JWTService.Abstract;
using RusMProject.Domain.Entities;
using RusMProject.Persistance.UnitOfWorkFolder;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Exceptions;
using RusMProjectApplication.Models.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Services
{
    public class UserManager : IUserService
    {
        public IJWTService JWTService { get; set; }
        public IApplicationSettingsAble ApplicationSettings { get; set; }
        public IUserReadRepository UserReadRepository { get; set; }
        public IMapper Mapper { get; set; }
        public UserManager(IJWTService jWTService,IApplicationSettingsAble applicationSettingsAble, IUserReadRepository userReadRepository, IMapper mapper)
        {
            JWTService = jWTService;
            ApplicationSettings = applicationSettingsAble;
            UserReadRepository = userReadRepository;
            Mapper = mapper;
        }
        public string GenerateToken(User user)
        {
            if (user == null)
                throw new NotFoundException("Not Found");

            return JWTService.GenerateToken(ApplicationSettings.JwtKey, new List<Claim>() { new Claim("Name", user.Name), new Claim("Id", user.Id.ToString()), new Claim("Email", user.Email.ToString()) }, 1);

            
        }
    }
}
