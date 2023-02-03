using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public int CreatorUser { get; set; }
        public DateTime CreatorDate { get; set; }
        public int? EditorUser { get; set; }
        public DateTime? EditorDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
    }
}
