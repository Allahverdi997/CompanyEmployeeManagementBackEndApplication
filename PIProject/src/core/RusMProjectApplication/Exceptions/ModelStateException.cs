using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Exceptions
{
    [Serializable]
    public class ModelStateException: CustomException
    {
        public ModelStateException() : base(500)
        {
            StatusCode = 500;
        }
        public ModelStateException(string message,string name) : base(500, message,name)
        {
            StatusCode = 500;
            ContentMessage = message;
            Name = name;
        }
        public ModelStateException(string name) : base(500, name)
        {
            StatusCode = 500;
            Name = name;
        }
        public ModelStateException(string message, string exceptionMessage,string name) : base(500, message, exceptionMessage,name)
        {
            StatusCode = 500;
            ContentMessage = message;
            ExceptionMessage = exceptionMessage;
            Name = name;
        }
    }
}
