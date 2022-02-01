using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblGoogleClickLog
    {
        public long Id { get; set; }
        public long ClickId { get; set; }
        public long ViewerId { get; set; }
        public DateTime DueDate { get; set; }
        public string Ip { get; set; }
        public short? LogType { get; set; }
        public string UniqueId { get; set; }

        public virtual TblGoogleClick Click { get; set; }
    }
}
