using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Contracts.v1.DataModels
{
    public class GoogleSearchDataModel
    {
        public string ID { get; set; }
        public string CustomerID { get; set; }

        public string WebSite { get; set; }
        public string TagName { get; set; }
        public string UniqueID { get; set; }

    }
}
