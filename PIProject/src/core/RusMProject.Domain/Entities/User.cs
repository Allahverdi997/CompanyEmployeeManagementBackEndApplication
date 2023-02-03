using RusMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RusMProject.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string SecretAnswer { get; set; }
        public string SecretQuestion { get; set; }

        //Relations
        [JsonIgnore]
        public ICollection<Department> Departments { get; set; }
        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
        [JsonIgnore]
        public ICollection<Department> DepartmentsEdit { get; set; }
        [JsonIgnore]
        public ICollection<Employee> EmployeesEdit { get; set; }
    }
}
