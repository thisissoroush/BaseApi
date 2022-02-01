using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblUser
    {
        public long Id { get; set; }
        public long PeopleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Sugar { get; set; }
        public bool? Active { get; set; }
        public DateTime LastModifyDate { get; set; }
        public short TypeId { get; set; }
        public long? OrganizationId { get; set; }
        public long? BranchId { get; set; }

        public virtual TblBranch Branch { get; set; }
        public virtual TblOrganization Organization { get; set; }
        public virtual TblPerson People { get; set; }
        public virtual TblUserType Type { get; set; }
    }
}
