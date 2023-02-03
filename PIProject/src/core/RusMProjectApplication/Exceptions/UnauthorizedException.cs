using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Exceptions
{
    [Serializable]
    public class UnauthorizedException:CustomException
    {
        public UnauthorizedException() : base(401)
        {
            StatusCode = 401;
        }
        public UnauthorizedException(string message,string name) : base(401, message,name)
        {
            StatusCode = 401;
            ContentMessage = message;
            Name = name;
        }
        public UnauthorizedException(string name) : base(401, name)
        {
            StatusCode = 401;
            Name = name;
        }
        public UnauthorizedException(string message, string exceptionMessage,string name) : base(401, message, exceptionMessage,name)
        {
            StatusCode = 401;
            ContentMessage = message;
            ExceptionMessage = exceptionMessage;
            Name = name;
        }
    }
}
