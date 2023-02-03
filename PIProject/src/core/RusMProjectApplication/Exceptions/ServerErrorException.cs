using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Exceptions
{
    [Serializable]
    public class ServerErrorException:CustomException
    {
        public ServerErrorException() : base(500)
        {
            StatusCode = 500;
        }
        public ServerErrorException(string message,string name) : base(500, message,name)
        {
            StatusCode = 500;
            ContentMessage = message;
            Name = name;
        }
        public ServerErrorException(string name) : base(500, name)
        {
            StatusCode = 500;
            Name = name;
        }
        public ServerErrorException(string message, string exceptionMessage,string name) : base(500, message, exceptionMessage,name)
        {
            StatusCode = 500;
            ContentMessage = message;
            ExceptionMessage = exceptionMessage;
            Name = name;
        }
    }
}
