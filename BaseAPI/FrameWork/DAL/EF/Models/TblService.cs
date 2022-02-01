using System;
using System.Collections.Generic;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class TblService
    {
        public TblService()
        {
            TblOffServices = new HashSet<TblOffService>();
            TblPayments = new HashSet<TblPayment>();
            TblPeriodicServices = new HashSet<TblPeriodicService>();
            TblServicesDetails = new HashSet<TblServicesDetail>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public int? StartDatePer { get; set; }
        public int? EndDatePer { get; set; }
        public int? StartDateEn { get; set; }
        public int? EndDateEn { get; set; }
        public string PeriodTitle { get; set; }
        public string Price { get; set; }
        public long CategoryId { get; set; }
        public int TypeId { get; set; }
        public long OrganizationId { get; set; }
        public long? BranchId { get; set; }
        public bool IsPeriodic { get; set; }

        public virtual TblBranch Branch { get; set; }
        public virtual TblCategory Category { get; set; }
        public virtual TblOrganization Organization { get; set; }
        public virtual ServicesType Type { get; set; }
        public virtual ICollection<TblOffService> TblOffServices { get; set; }
        public virtual ICollection<TblPayment> TblPayments { get; set; }
        public virtual ICollection<TblPeriodicService> TblPeriodicServices { get; set; }
        public virtual ICollection<TblServicesDetail> TblServicesDetails { get; set; }
    }
}
