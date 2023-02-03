using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Exceptions
{
    [Serializable]
    public class BadRequestException:CustomException
    {
        public BadRequestException() : base(400)
        {
            StatusCode = 400;
        }
        public BadRequestException(string message,string name) : base(400, message,name)
        {
            StatusCode = 400;
            ContentMessage = message;
            Name = name;
        }

        public BadRequestException(string name) : base(400, name)
        {
            StatusCode = 400;
            Name = name;
        }
        public BadRequestException(string message, string exceptionMessage,string name) : base(400, message,exceptionMessage,name)
        {
            StatusCode = 400;
            ContentMessage = message;
            ExceptionMessage = exceptionMessage;
            Name = name;
        }
    }
}
