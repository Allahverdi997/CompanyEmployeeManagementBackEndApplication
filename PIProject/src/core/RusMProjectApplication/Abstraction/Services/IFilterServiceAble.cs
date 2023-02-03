using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction.Services
{
    public interface IFilterServiceAble
    {
        public void SetSecretKey(string secretKey);
        void AuthenticateUser(string token);
    }
}
