using RusMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RusMProject.Domain.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Relations
        [JsonIgnore]
        public List<Employee> Employees { get; set; }
        [JsonIgnore]
        public User CreateUser { get; set; }
        [JsonIgnore]
        public User EditUser { get; set; }
    }
}
