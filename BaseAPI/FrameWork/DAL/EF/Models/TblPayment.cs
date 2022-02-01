using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblPayment
    {
        public TblPayment()
        {
            TblTransactions = new HashSet<TblTransaction>();
        }

        public long Id { get; set; }
        public DateTime DueDate { get; set; }
        public long ServiceId { get; set; }
        public long UserId { get; set; }
        public long OffServiceId { get; set; }
        public string Paid { get; set; }
        public short PaymentTypeId { get; set; }

        public virtual TblOffService OffService { get; set; }
        public virtual TblPaymentType PaymentType { get; set; }
        public virtual TblService Service { get; set; }
        public virtual TblUser User { get; set; }
        public virtual ICollection<TblTransaction> TblTransactions { get; set; }
    }
}
