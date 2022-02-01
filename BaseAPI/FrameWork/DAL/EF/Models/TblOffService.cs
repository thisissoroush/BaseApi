using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblOffService
    {
        public TblOffService()
        {
            TblPayments = new HashSet<TblPayment>();
        }

        public long Id { get; set; }
        public long ServiceId { get; set; }
        public string Code { get; set; }
        public string StartDatePer { get; set; }
        public string EndDatePer { get; set; }
        public string StartDateEn { get; set; }
        public string EndDateEn { get; set; }

        public virtual TblService Service { get; set; }
        public virtual ICollection<TblPayment> TblPayments { get; set; }
    }
}
