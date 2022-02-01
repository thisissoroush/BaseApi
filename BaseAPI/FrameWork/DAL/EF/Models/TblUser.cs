using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblUser
    {
        public TblUser()
        {
            TblArticles = new HashSet<TblArticle>();
            TblGoogleClicks = new HashSet<TblGoogleClick>();
            TblPayments = new HashSet<TblPayment>();
            TblUserContactInfos = new HashSet<TblUserContactInfo>();
            TblUserRoles = new HashSet<TblUserRole>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Sugar { get; set; }
        public bool? Active { get; set; }
        public DateTime LastModifyDate { get; set; }
        public long? OrganizationId { get; set; }
        public long? BranchId { get; set; }

        public virtual TblBranch Branch { get; set; }
        public virtual TblGoogleClickScore IdNavigation { get; set; }
        public virtual TblOrganization Organization { get; set; }
        public virtual ICollection<TblArticle> TblArticles { get; set; }
        public virtual ICollection<TblGoogleClick> TblGoogleClicks { get; set; }
        public virtual ICollection<TblPayment> TblPayments { get; set; }
        public virtual ICollection<TblUserContactInfo> TblUserContactInfos { get; set; }
        public virtual ICollection<TblUserRole> TblUserRoles { get; set; }
    }
}
