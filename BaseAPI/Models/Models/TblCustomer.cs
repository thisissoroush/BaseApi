using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblCustomer
    {
        public TblCustomer()
        {
            TblGoogleClickScores = new HashSet<TblGoogleClickScore>();
            TblGoogleClicks = new HashSet<TblGoogleClick>();
            TblPayments = new HashSet<TblPayment>();
        }

        public long Id { get; set; }
        public long PeopleId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Sugar { get; set; }
        public DateTime LastModifyDate { get; set; }

        public virtual TblPerson People { get; set; }
        public virtual ICollection<TblGoogleClickScore> TblGoogleClickScores { get; set; }
        public virtual ICollection<TblGoogleClick> TblGoogleClicks { get; set; }
        public virtual ICollection<TblPayment> TblPayments { get; set; }
    }
}
