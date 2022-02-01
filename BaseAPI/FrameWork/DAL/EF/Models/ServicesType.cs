using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class ServicesType
    {
        public ServicesType()
        {
            TblServices = new HashSet<TblService>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblService> TblServices { get; set; }
    }
}
