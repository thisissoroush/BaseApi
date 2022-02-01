using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblGoogleClick
    {
        public TblGoogleClick()
        {
            TblGoogleClickLogs = new HashSet<TblGoogleClickLog>();
        }

        public long Id { get; set; }
        public string Website { get; set; }
        public string TagName { get; set; }
        public long TodaySearchedCounts { get; set; }
        public long TotalSearchedCounts { get; set; }
        public long TodayClickedCounts { get; set; }
        public long TotalClickedCounts { get; set; }
        public DateTime CreateDate { get; set; }
        public long UserId { get; set; }
        public bool IsActive { get; set; }
        public int? ClickPerDay { get; set; }

        public virtual TblUser User { get; set; }
        public virtual ICollection<TblGoogleClickLog> TblGoogleClickLogs { get; set; }
    }
}
