using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblLog
    {
        public long Id { get; set; }
        public string Who { get; set; }
        public string What { get; set; }
        public string Where { get; set; }
        public string When { get; set; }
        public DateTime DueDate { get; set; }
    }
}
