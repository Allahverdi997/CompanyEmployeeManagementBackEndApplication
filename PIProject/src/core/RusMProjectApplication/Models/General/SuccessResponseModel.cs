using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Models.General
{
    public class SuccessResponseModel : IBaseResponseModelAble
    {
        public SuccessResponseModel(string message, object data)
        {
            Message = message;
            Data = data;
            Success = true;
        }
        public SuccessResponseModel(object data)
        {
            Message = string.Empty;
            Data = data;
            Success = true;
        }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
    }
}
