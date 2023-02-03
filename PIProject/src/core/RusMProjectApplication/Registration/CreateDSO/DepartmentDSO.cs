using RusMProjectApplication.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Registration.CreateDSO
{
    public class DepartmentDSO:ICreateDSOAble
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
