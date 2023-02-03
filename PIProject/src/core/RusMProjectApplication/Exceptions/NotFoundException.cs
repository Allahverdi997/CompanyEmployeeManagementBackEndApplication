using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Exceptions
{
    [Serializable]
    public class NotFoundException:CustomException
    {
        public NotFoundException() : base(404)
        {
            StatusCode = 404;
        }
        public NotFoundException(string message,string name) : base(404, message,name)
        {
            StatusCode = 404;
            ContentMessage = message;
            Name = name;
        }
        public NotFoundException(string name) : base(404, name)
        {
            StatusCode = 404;
            Name = name;
        }
        public NotFoundException(string message, string exceptionMessage,string name) : base(404, message, exceptionMessage,name)
        {
            StatusCode = 404;
            ContentMessage = message;
            ExceptionMessage = exceptionMessage;
            Name = name;
        }
    }
}
