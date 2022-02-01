using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblServicesDetail
    {
        public long Id { get; set; }
        public long ServicesId { get; set; }
        public int TypeId { get; set; }

        public virtual TblService Services { get; set; }
        public virtual ServicesDetailType Type { get; set; }
    }
}
