using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblUserType
    {
        public TblUserType()
        {
            TblUsers = new HashSet<TblUser>();
        }

        public short Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
