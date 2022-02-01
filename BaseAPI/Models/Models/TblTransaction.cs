using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblTransaction
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime DueDate { get; set; }
        public long PaymentId { get; set; }

        public virtual TblPayment Payment { get; set; }
    }
}
