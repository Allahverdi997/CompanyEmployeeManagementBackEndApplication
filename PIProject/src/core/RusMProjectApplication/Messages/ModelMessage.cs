using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProjectApplication.Messages
{
    public class ModelMessage
    {
        public static string NoData { get;  } = "There is no data";
        public static string CancelToken { get;  } = "Token is cancelled";
        public static string CanNotAdded { get;  } = "Data can't be added";
        public static string CanNotUpdated { get;  } = "Data can't be updated.Because, there is data not data in database with id";
        public static string CanNotDeleted { get; } = "Data can't be deleted.Because, there is data not data in database with id";

        public static string CanAdded { get;  } = "Data added";
        public static string CanUpdated { get;  } = "Data updated";
        public static string CanDeleted { get; } = "Data deleted";

        public static string Data { get;  } = "There are data";
        public static string SingleData { get; } = "There is data";
    }
}
