using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblUserContactInfo
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Value { get; set; }
        public short TypeId { get; set; }
        public bool IsPrimary { get; set; }

        public virtual TblContactInfoType Type { get; set; }
        public virtual TblUser User { get; set; }
    }
}
