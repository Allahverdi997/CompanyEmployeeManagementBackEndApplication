using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Abstraction
{
    public interface IBaseResponseModelAble
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }
    }
}
