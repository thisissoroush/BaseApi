using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblOrganizationContactInfo
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string Value { get; set; }
        public short TypeId { get; set; }

        public virtual TblOrganization Organization { get; set; }
        public virtual TblContactInfoType Type { get; set; }
    }
}
