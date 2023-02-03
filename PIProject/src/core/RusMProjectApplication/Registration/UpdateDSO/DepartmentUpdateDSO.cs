using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Registration.UpdateDSO
{
    public class DepartmentUpdateDSO: GeneralUpdateDSO,IUpdateDSOAble
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
