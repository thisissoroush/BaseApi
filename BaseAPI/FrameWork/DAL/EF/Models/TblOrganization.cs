using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblOrganization
    {
        public TblOrganization()
        {
            TblBranches = new HashSet<TblBranch>();
            TblContactServersInfos = new HashSet<TblContactServersInfo>();
            TblOrganizationContactInfos = new HashSet<TblOrganizationContactInfo>();
            TblServices = new HashSet<TblService>();
            TblUsers = new HashSet<TblUser>();
        }

        public long Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblBranch> TblBranches { get; set; }
        public virtual ICollection<TblContactServersInfo> TblContactServersInfos { get; set; }
        public virtual ICollection<TblOrganizationContactInfo> TblOrganizationContactInfos { get; set; }
        public virtual ICollection<TblService> TblServices { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
