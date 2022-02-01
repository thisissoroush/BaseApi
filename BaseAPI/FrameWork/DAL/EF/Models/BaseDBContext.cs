using System;
using FrameWork.DAL.ConnectionString;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FrameWork.DAL.EF.Models
{
    public partial class BaseDBContext : DbContext
    {
        private readonly IDbConnector _conStr;
        public BaseDBContext(){}

        public BaseDBContext(DbContextOptions<BaseDBContext> options, IDbConnector conStr)
            : base(options)
        {
            _conStr = conStr;
        }

        public virtual DbSet<ServicesDetailType> ServicesDetailTypes { get; set; }
        public virtual DbSet<ServicesType> ServicesTypes { get; set; }
        public virtual DbSet<TblArticle> TblArticles { get; set; }
        public virtual DbSet<TblArticleComment> TblArticleComments { get; set; }
        public virtual DbSet<TblArticleType> TblArticleTypes { get; set; }
        public virtual DbSet<TblBranch> TblBranches { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblContactInfoType> TblContactInfoTypes { get; set; }
        public virtual DbSet<TblContactServersInfo> TblContactServersInfos { get; set; }
        public virtual DbSet<TblGoogleClick> TblGoogleClicks { get; set; }
        public virtual DbSet<TblGoogleClickLog> TblGoogleClickLogs { get; set; }
        public virtual DbSet<TblGoogleClickLogType> TblGoogleClickLogTypes { get; set; }
        public virtual DbSet<TblGoogleClickScore> TblGoogleClickScores { get; set; }
        public virtual DbSet<TblLog> TblLogs { get; set; }
        public virtual DbSet<TblOffService> TblOffServices { get; set; }
        public virtual DbSet<TblOrganization> TblOrganizations { get; set; }
        public virtual DbSet<TblOrganizationContactInfo> TblOrganizationContactInfos { get; set; }
        public virtual DbSet<TblPayment> TblPayments { get; set; }
        public virtual DbSet<TblPaymentType> TblPaymentTypes { get; set; }
        public virtual DbSet<TblPeriodicService> TblPeriodicServices { get; set; }
        public virtual DbSet<TblPeriodicServiceType> TblPeriodicServiceTypes { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblService> TblServices { get; set; }
        public virtual DbSet<TblServicesDetail> TblServicesDetails { get; set; }
        public virtual DbSet<TblTagName> TblTagNames { get; set; }
        public virtual DbSet<TblTransaction> TblTransactions { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserContactInfo> TblUserContactInfos { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }
        public virtual DbSet<TblVisistedSite> TblVisistedSites { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_conStr.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<ServicesDetailType>(entity =>
            {
                entity.ToTable("ServicesDetailType", "Core");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ServicesType>(entity =>
            {
                entity.ToTable("ServicesTypes", "Core");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblArticle>(entity =>
            {
                entity.ToTable("tblArticles", "article");

                entity.HasIndex(e => e.Title, "IX_tblArticles");

                entity.Property(e => e.Article).IsRequired();

                entity.Property(e => e.ArticleTypeId).HasColumnName("ArticleTypeID");

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ArticleType)
                    .WithMany(p => p.TblArticles)
                    .HasForeignKey(d => d.ArticleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblArticles_tblArticleTypes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblArticles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblArticles_tblUsers");
            });

            modelBuilder.Entity<TblArticleComment>(entity =>
            {
                entity.ToTable("tblArticleComments", "article");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleId).HasColumnName("ArticleID");

                entity.Property(e => e.Comment).IsRequired();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.TblArticleComments)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblArticleComments_tblArticles");
            });

            modelBuilder.Entity<TblArticleType>(entity =>
            {
                entity.ToTable("tblArticleTypes", "article");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblBranch>(entity =>
            {
                entity.ToTable("tblBranches", "Org");

                entity.HasIndex(e => e.OrganizationId, "NCI_tblBranches_OrganizationID");

                entity.HasIndex(e => e.ParentId, "NCI_tblBranches_ParentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblBranches)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblBranches_tblOrganizations");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.ToTable("tblCategories", "Core");

                entity.HasIndex(e => e.ParentId, "NCI_tblCategories_ParentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblContactInfoType>(entity =>
            {
                entity.ToTable("tblContactInfoType", "Com");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TblContactServersInfo>(entity =>
            {
                entity.ToTable("tblContactServersInfo", "Com");

                entity.HasIndex(e => e.OrganizationId, "NCI_tblContactServersInfo_OrganizationID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.From)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProviderCustomUrl)
                    .HasMaxLength(200)
                    .HasColumnName("ProviderCustomURL");

                entity.Property(e => e.ProviderId).HasColumnName("ProviderID");

                entity.Property(e => e.ProxyPassord).HasMaxLength(100);

                entity.Property(e => e.ProxyPort).HasMaxLength(5);

                entity.Property(e => e.ProxyServer).HasMaxLength(200);

                entity.Property(e => e.ProxyUserName).HasMaxLength(100);

                entity.Property(e => e.Sslport)
                    .HasMaxLength(5)
                    .HasColumnName("SSLPort");

                entity.Property(e => e.UseSsl).HasColumnName("UseSSL");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblContactServersInfos)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContactServersInfo_tblOrganizations");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.TblContactServersInfos)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblContactServersInfo_tblContactInfoType");
            });

            modelBuilder.Entity<TblGoogleClick>(entity =>
            {
                entity.ToTable("tblGoogleClick", "Core");

                entity.HasIndex(e => new { e.Website, e.TagName, e.UserId }, "IX_tblGoogleClick")
                    .IsUnique();

                entity.HasIndex(e => new { e.UserId, e.IsActive }, "IX_tblGoogleClick_CUTOMERID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblGoogleClicks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblGoogleClick_tblUsers");
            });

            modelBuilder.Entity<TblGoogleClickLog>(entity =>
            {
                entity.ToTable("tblGoogleClickLogs", "Core");

                entity.HasIndex(e => new { e.ClickId, e.ViewerId, e.UniqueId, e.Ip }, "IX_GoogleClickLogs");

                entity.HasIndex(e => e.DueDate, "NCI_tblGoogleClickLogs_TIME");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClickId).HasColumnName("ClickID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .HasColumnName("IP");

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(40)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.ViewerId).HasColumnName("ViewerID");

                entity.HasOne(d => d.Click)
                    .WithMany(p => p.TblGoogleClickLogs)
                    .HasForeignKey(d => d.ClickId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClickID_tblGoogleClickID");
            });

            modelBuilder.Entity<TblGoogleClickLogType>(entity =>
            {
                entity.ToTable("tblGoogleClickLogTypes", "Core");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblGoogleClickScore>(entity =>
            {
                entity.ToTable("tblGoogleClickScore", "Core");

                entity.HasIndex(e => e.UserId, "IX_tblGoogleClickScore");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<TblLog>(entity =>
            {
                entity.ToTable("tblLogs", "Core");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DueDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.What)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.When)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(getdate())")
                    .IsFixedLength(true);

                entity.Property(e => e.Where)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Who)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblOffService>(entity =>
            {
                entity.ToTable("tblOffService", "Core");

                entity.HasIndex(e => e.Code, "NCI_tblOffService_Code");

                entity.HasIndex(e => e.EndDateEn, "NCI_tblOffService_EndDateEn");

                entity.HasIndex(e => e.EndDatePer, "NCI_tblOffService_EndDatePer");

                entity.HasIndex(e => e.ServiceId, "NCI_tblOffService_ServiceID");

                entity.HasIndex(e => e.StartDateEn, "NCI_tblOffService_StartDateEn");

                entity.HasIndex(e => e.StartDatePer, "NCI_tblOffService_StartDatePer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EndDateEn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.EndDatePer)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.StartDateEn)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.StartDatePer)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TblOffServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOffService_tblServices");
            });

            modelBuilder.Entity<TblOrganization>(entity =>
            {
                entity.ToTable("tblOrganizations", "Org");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TblOrganizationContactInfo>(entity =>
            {
                entity.ToTable("tblOrganizationContactInfo", "Com");

                entity.HasIndex(e => e.OrganizationId, "NCI_tblOrganizationContactInfo_OrganizationID");

                entity.HasIndex(e => e.TypeId, "NCI_tblOrganizationContactInfo_TypeID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblOrganizationContactInfos)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrganizationContactInfo_tblOrganizations");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblOrganizationContactInfos)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblOrganizationContactInfo_tblContactInfoType");
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.ToTable("tblPayments", "Core");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DueDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OffServiceId).HasColumnName("OffServiceID");

                entity.Property(e => e.Paid)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.OffService)
                    .WithMany(p => p.TblPayments)
                    .HasForeignKey(d => d.OffServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPayments_tblOffService");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.TblPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPayments_tblPaymentTypes");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TblPayments)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPayments_tblServices");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPayments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPayments_tblUsers");
            });

            modelBuilder.Entity<TblPaymentType>(entity =>
            {
                entity.ToTable("tblPaymentTypes");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<TblPeriodicService>(entity =>
            {
                entity.ToTable("tblPeriodicService", "Core");

                entity.HasIndex(e => new { e.ServiceId, e.IsOneTime, e.IsUsed }, "IX_tblPeriodicService");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.WebSite).HasMaxLength(200);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TblPeriodicServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPeriodicService_tblServices");
            });

            modelBuilder.Entity<TblPeriodicServiceType>(entity =>
            {
                entity.ToTable("tblPeriodicServiceTypes", "Core");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRoles", "Users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblService>(entity =>
            {
                entity.ToTable("tblServices", "Core");

                entity.HasIndex(e => e.BranchId, "NCI_tblServices_BranchID");

                entity.HasIndex(e => e.CategoryId, "NCI_tblServices_CategoryID");

                entity.HasIndex(e => e.EndDateEn, "NCI_tblServices_EndDateEn");

                entity.HasIndex(e => e.EndDatePer, "NCI_tblServices_EndDatePer");

                entity.HasIndex(e => e.OrganizationId, "NCI_tblServices_OrganizationID");

                entity.HasIndex(e => e.Price, "NCI_tblServices_Price");

                entity.HasIndex(e => e.StartDateEn, "NCI_tblServices_StartDateEn");

                entity.HasIndex(e => e.StartDatePer, "NCI_tblServices_StartDatePer");

                entity.HasIndex(e => e.TypeId, "NCI_tblServices_TypeID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.PeriodTitle).HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TblServices)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_tblServices_tblBranches");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblServices)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblServices_tblCategories");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblServices)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblServices_tblOrganizations");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblServices)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblServices_ServicesTypes");
            });

            modelBuilder.Entity<TblServicesDetail>(entity =>
            {
                entity.ToTable("tblServicesDetail", "Core");

                entity.HasIndex(e => e.TypeId, "NCI_tblServicesDetail_TypeID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServicesId).HasColumnName("ServicesID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Services)
                    .WithMany(p => p.TblServicesDetails)
                    .HasForeignKey(d => d.ServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblServicesDetail_tblServices");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblServicesDetails)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblServicesDetail_ServicesDetailType");
            });

            modelBuilder.Entity<TblTagName>(entity =>
            {
                entity.ToTable("tblTagNames", "Core");

                entity.Property(e => e.PeriodicServiceId).HasColumnName("PeriodicServiceID");

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.PeriodicService)
                    .WithMany(p => p.TblTagNames)
                    .HasForeignKey(d => d.PeriodicServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTagNames_tblPeriodicService");
            });

            modelBuilder.Entity<TblTransaction>(entity =>
            {
                entity.ToTable("tblTransactions", "Core");

                entity.HasIndex(e => e.Code, "NCI_tblTransactions_Code");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DueDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TblTransactions)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTransactions_tblPayments");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUsers", "Users");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastModifyDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Sugar)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_tblUsers_tblBranches");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.TblUser)
                    .HasForeignKey<TblUser>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUsers_tblGoogleClickScore");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_tblUsers_tblOrganizations");
            });

            modelBuilder.Entity<TblUserContactInfo>(entity =>
            {
                entity.ToTable("tblUserContactInfo", "Com");

                entity.HasIndex(e => e.UserId, "NCI_tblPeopleContactInfo_PeopleID");

                entity.HasIndex(e => e.TypeId, "NCI_tblPeopleContactInfo_TypeID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblUserContactInfos)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPeopleContactInfo_tblContactInfoType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserContactInfos)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserContactInfo_tblUsers");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.ToTable("tblUserRoles", "Users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserRoles_tblRoles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUserRoles_tblUsers");
            });

            modelBuilder.Entity<TblVisistedSite>(entity =>
            {
                entity.ToTable("tblVisistedSites", "Core");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DueDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.WebSite)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
