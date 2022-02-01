using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class ServicesDetailType
    {
        public ServicesDetailType()
        {
            TblServicesDetails = new HashSet<TblServicesDetail>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<TblServicesDetail> TblServicesDetails { get; set; }
    }
}
