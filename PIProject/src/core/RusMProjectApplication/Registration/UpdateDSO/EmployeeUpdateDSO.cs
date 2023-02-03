using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Registration.UpdateDSO
{
    public class EmployeeUpdateDSO:GeneralUpdateDSO,IUpdateDSOAble
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
