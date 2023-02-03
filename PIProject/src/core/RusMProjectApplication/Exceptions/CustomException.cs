using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Exceptions
{
    [Serializable]
    public class CustomException:Exception
    {
        public CustomException(int statusCode) : base()
        {
            StatusCode = statusCode;
        }
        public CustomException(int statusCode, string message,string name) : base(message)
        {
            StatusCode = statusCode;
            ContentMessage = message;
            Name = name;
        }
        public CustomException(int statusCode, string name) : base()
        {
            StatusCode = statusCode;
            Name = name;
        }
        public CustomException(int statusCode,string message,string exceptionMessage,string name):base(message)
        {
            StatusCode = statusCode;
            ContentMessage = message;
            ExceptionMessage = exceptionMessage;
            Name = name;
        }
        public CustomException() : base()
        {
        }
        public string Name { get; set; }
        public int StatusCode { get; set; }
        public string ContentMessage { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
