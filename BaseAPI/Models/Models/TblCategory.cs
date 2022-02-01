using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblServices = new HashSet<TblService>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }

        public virtual ICollection<TblService> TblServices { get; set; }
    }
}
