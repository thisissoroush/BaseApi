using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Contracts.v1.RequestModels
{
    public class GoogleSearchRequest
    {
        public string ID { get; set; }
        public bool GotClicked { get; set; }
        public string Who { get; set; }
        public string UniqueID { get; set; }


    }
}
