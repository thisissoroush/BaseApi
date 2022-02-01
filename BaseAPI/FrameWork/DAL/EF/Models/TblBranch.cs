using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblBranch
    {
        public TblBranch()
        {
            TblServices = new HashSet<TblService>();
            TblUsers = new HashSet<TblUser>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public long OrganizationId { get; set; }
        public long? ParentId { get; set; }

        public virtual TblOrganization Organization { get; set; }
        public virtual ICollection<TblService> TblServices { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
