using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblPeopleContactInfo
    {
        public long Id { get; set; }
        public long PeopleId { get; set; }
        public string Value { get; set; }
        public short TypeId { get; set; }
        public bool IsPrimary { get; set; }

        public virtual TblPerson People { get; set; }
        public virtual TblContactInfoType Type { get; set; }
    }
}
