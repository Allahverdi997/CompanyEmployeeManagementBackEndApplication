using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Models.General
{
    public class ErrorResponseModel : IBaseResponseModelAble
    {
        public ErrorResponseModel(string message)
        {
            Message = message;
            Data = null;
            Success = false;
        }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
    }
}
