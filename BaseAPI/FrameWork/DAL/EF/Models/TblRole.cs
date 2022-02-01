using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUserRoles = new HashSet<TblUserRole>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
    }
}
