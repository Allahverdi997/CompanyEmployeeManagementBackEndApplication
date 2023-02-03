using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Messages
{
    public class ValidationMessage
    {
        public static string NotEmpty { get; set; } = "NotEmpty";
        public static string MinimumLengthTwo { get; set; } = "MinimumLengthTwo";
    }
}
