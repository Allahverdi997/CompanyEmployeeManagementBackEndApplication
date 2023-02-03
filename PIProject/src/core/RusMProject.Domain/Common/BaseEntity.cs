using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RusMProject.Domain.Common
{
    public class BaseEntity:IEntity
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int CreatorUserId { get; set; }
        [JsonIgnore]
        public DateTime CreatorDate { get; set; }
        [JsonIgnore]
        public int? EditorUserId { get; set; }
        [JsonIgnore]
        public DateTime? EditorDate { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; }

    }
}
