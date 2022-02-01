using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblTagName
    {
        public long Id { get; set; }
        public long PeriodicServiceId { get; set; }
        public string Tag { get; set; }

        public virtual TblPeriodicService PeriodicService { get; set; }
    }
}
