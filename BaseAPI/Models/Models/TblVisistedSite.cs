using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblVisistedSite
    {
        public long Id { get; set; }
        public string WebSite { get; set; }
        public string TagName { get; set; }
        public DateTime DueDate { get; set; }
    }
}
