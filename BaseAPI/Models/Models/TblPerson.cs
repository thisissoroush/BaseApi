using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class TblPerson
    {
        public TblPerson()
        {
            TblArticles = new HashSet<TblArticle>();
            TblCustomers = new HashSet<TblCustomer>();
            TblPeopleContactInfos = new HashSet<TblPeopleContactInfo>();
            TblUsers = new HashSet<TblUser>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string NationalCode { get; set; }

        public virtual ICollection<TblArticle> TblArticles { get; set; }
        public virtual ICollection<TblCustomer> TblCustomers { get; set; }
        public virtual ICollection<TblPeopleContactInfo> TblPeopleContactInfos { get; set; }
        public virtual ICollection<TblUser> TblUsers { get; set; }
    }
}
