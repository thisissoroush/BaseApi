using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblPeriodicService
    {
        public TblPeriodicService()
        {
            TblTagNames = new HashSet<TblTagName>();
        }

        public long Id { get; set; }
        public long ServiceId { get; set; }
        public bool IsOneTime { get; set; }
        public bool IsUsed { get; set; }
        public string WebSite { get; set; }

        public virtual TblService Service { get; set; }
        public virtual ICollection<TblTagName> TblTagNames { get; set; }
    }
}
