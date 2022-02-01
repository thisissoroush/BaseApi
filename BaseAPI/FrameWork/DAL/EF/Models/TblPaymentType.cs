using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblPaymentType
    {
        public TblPaymentType()
        {
            TblPayments = new HashSet<TblPayment>();
        }

        public short Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblPayment> TblPayments { get; set; }
    }
}
