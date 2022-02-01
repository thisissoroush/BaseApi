using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblContactInfoType
    {
        public TblContactInfoType()
        {
            TblContactServersInfos = new HashSet<TblContactServersInfo>();
            TblOrganizationContactInfos = new HashSet<TblOrganizationContactInfo>();
            TblPeopleContactInfos = new HashSet<TblPeopleContactInfo>();
        }

        public short Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblContactServersInfo> TblContactServersInfos { get; set; }
        public virtual ICollection<TblOrganizationContactInfo> TblOrganizationContactInfos { get; set; }
        public virtual ICollection<TblPeopleContactInfo> TblPeopleContactInfos { get; set; }
    }
}
