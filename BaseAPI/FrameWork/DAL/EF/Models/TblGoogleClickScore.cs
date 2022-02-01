using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblGoogleClickScore
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long Score { get; set; }

        public virtual TblUser TblUser { get; set; }
    }
}
