using RusMProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Domain.Entities
{
    public class ExceptionNotification:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
