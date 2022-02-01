using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblUserRole
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public int RoleId { get; set; }

        public virtual TblRole Role { get; set; }
        public virtual TblUser User { get; set; }
    }
}
