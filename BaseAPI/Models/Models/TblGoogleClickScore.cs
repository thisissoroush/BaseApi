using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblGoogleClickScore
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long Score { get; set; }

        public virtual TblCustomer Customer { get; set; }
    }
}
