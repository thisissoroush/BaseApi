using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblContactInfoType
    {
        public TblContactInfoType()
        {
            TblContactServersInfos = new HashSet<TblContactServersInfo>();
            TblOrganizationContactInfos = new HashSet<TblOrganizationContactInfo>();
            TblUserContactInfos = new HashSet<TblUserContactInfo>();
        }

        public short Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblContactServersInfo> TblContactServersInfos { get; set; }
        public virtual ICollection<TblOrganizationContactInfo> TblOrganizationContactInfos { get; set; }
        public virtual ICollection<TblUserContactInfo> TblUserContactInfos { get; set; }
    }
}
