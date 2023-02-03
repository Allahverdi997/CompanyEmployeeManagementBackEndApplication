
using JWTService.Abstract;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Infrastructure.Services
{
    public class FilterManager:IFilterServiceAble
    {
        public  IUserSessionAble UserSessionAble { get; set; }
        public IJWTService JWTService { get; set; }
        public IUserReadRepository UserReadRepository { get; set; }
        public FilterManager(IUserSessionAble userSessionAble,IJWTService jWTService,IUserReadRepository userReadRepository)
        {
            UserSessionAble = userSessionAble;
            JWTService= jWTService;
            UserReadRepository = userReadRepository;

        }

        public void SetSecretKey(string secretKey)
        {
            if (!string.IsNullOrEmpty(secretKey))
            {
                UserSessionAble.SecretKey = secretKey;
            }
        }

        void IFilterServiceAble.AuthenticateUser(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new UnauthorizedException("AuthenticationTokenIsRequired");

            if(!JWTService.VerifyToken(token))
                throw new UnauthorizedException("AuthenticationTokenIsExpired");

            UserSessionAble.AuthToken = token;
            UserSessionAble.User =UserReadRepository.GetAsync(Convert.ToInt32(JWTService.DegenerateToken(token,"Id").Value)).Result;
        }
    }
}
