using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemandWebService
{
    public partial class DemandContext : DbContext
    {
        public DemandContext()
        {
        }

        public DemandContext(DbContextOptions<DemandContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttachmentHeader> AttachmentHeader { get; set; }
        public virtual DbSet<AttachmentPurchase> AttachmentPurchase { get; set; }
        public virtual DbSet<Deliveries> Deliveries { get; set; }
        public virtual DbSet<DemandArchive> DemandArchive { get; set; }
        public virtual DbSet<DemandHeader> DemandHeader { get; set; }
        public virtual DbSet<DemandHeaderArchive> DemandHeaderArchive { get; set; }
        public virtual DbSet<DemandPurchase> DemandPurchase { get; set; }
        public virtual DbSet<DemandsInUse> DemandsInUse { get; set; }
        public virtual DbSet<DepartmentExecute> DepartmentExecute { get; set; }
        public virtual DbSet<Deputy> Deputy { get; set; }
        public virtual DbSet<DpStatus> DpStatus { get; set; }
        public virtual DbSet<Housing> Housing { get; set; }
        public virtual DbSet<Problems> Problems { get; set; }
        public virtual DbSet<ProjectCost> ProjectCost { get; set; }

        // Unable to generate entity type for table 'dbo.DemandHeaderChanges'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tels'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SubDiv1C'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DemandPurchaseChanges'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TransID'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.WhatsNew'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DepartmnetBranch'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.JustificationStandart'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.JustificationLastSelect_Result'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QI8K6F1;Database=Demand;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AttachmentHeader>(entity =>
            {
                entity.HasKey(e => e.FileId);

                entity.Property(e => e.FileId).HasColumnName("fileID");

                entity.Property(e => e.DphId).HasColumnName("dphID");

                entity.Property(e => e.FileAttach)
                    .IsRequired()
                    .HasColumnName("fileAttach");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dph)
                    .WithMany(p => p.AttachmentHeader)
                    .HasForeignKey(d => d.DphId)
                    .HasConstraintName("FK_AttachmentHeader_DemandHeader");
            });

            modelBuilder.Entity<AttachmentPurchase>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK_Attachment");

                entity.Property(e => e.FileId).HasColumnName("fileID");

                entity.Property(e => e.DpId).HasColumnName("dpID");

                entity.Property(e => e.FileAttach)
                    .IsRequired()
                    .HasColumnName("fileAttach");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("fileName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dp)
                    .WithMany(p => p.AttachmentPurchase)
                    .HasForeignKey(d => d.DpId)
                    .HasConstraintName("FK_AttachmentPurchase_DemandPurchase");
            });

            modelBuilder.Entity<Deliveries>(entity =>
            {
                entity.HasKey(e => e.DeliveryId);

                entity.Property(e => e.DeliveryId)
                    .HasColumnName("deliveryID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeliveryName)
                    .IsRequired()
                    .HasColumnName("deliveryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DemandArchive>(entity =>
            {
                entity.HasKey(e => e.DaId);

                entity.HasIndex(e => e.DahId)
                    .HasName("IX_DAdahID");

                entity.HasIndex(e => e.DpId)
                    .HasName("IX_DAdpID");

                entity.Property(e => e.DaId).HasColumnName("daID");

                entity.Property(e => e.DaAction)
                    .IsRequired()
                    .HasColumnName("daAction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DaFieldsChanged)
                    .HasColumnName("daFieldsChanged")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DahId).HasColumnName("dahID");

                entity.Property(e => e.DateCorr)
                    .HasColumnName("dateCorr")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartmentExec)
                    .IsRequired()
                    .HasColumnName("departmentExec")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DE')");

                entity.Property(e => e.DpAmount).HasColumnName("dpAmount");

                entity.Property(e => e.DpComment)
                    .HasColumnName("dpComment")
                    .IsUnicode(false);

                entity.Property(e => e.DpExecutor)
                    .HasColumnName("dpExecutor")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DpId).HasColumnName("dpID");

                entity.Property(e => e.DpNum).HasColumnName("dpNum");

                entity.Property(e => e.DpStatusId).HasColumnName("dpStatusID");

                entity.Property(e => e.DpSubject)
                    .IsRequired()
                    .HasColumnName("dpSubject")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DpUnit)
                    .IsRequired()
                    .HasColumnName("dpUnit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DphId).HasColumnName("dphID");

                entity.Property(e => e.ExecutorMail)
                    .HasColumnName("executorMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExecutorTelephone)
                    .HasColumnName("executorTelephone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FirmId)
                    .HasColumnName("firmID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FirmName)
                    .HasColumnName("firmName")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.HousingId).HasColumnName("housingID");

                entity.Property(e => e.ItemCatNum).HasColumnName("itemCatNum");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.ProdCatNum)
                    .HasColumnName("prodCatNum")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProdCatNumExist)
                    .HasColumnName("prodCatNumExist")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QualificationId)
                    .HasColumnName("qualificationID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TokenTrans)
                    .HasColumnName("tokenTrans")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserCorr)
                    .IsRequired()
                    .HasColumnName("userCorr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkstationCorr)
                    .IsRequired()
                    .HasColumnName("workstationCorr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dah)
                    .WithMany(p => p.DemandArchive)
                    .HasForeignKey(d => d.DahId)
                    .HasConstraintName("FK_DemandArchive_DemandHeaderArchive");

                entity.HasOne(d => d.DpStatus)
                    .WithMany(p => p.DemandArchive)
                    .HasForeignKey(d => d.DpStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandArchive_DpStatus");
            });

            modelBuilder.Entity<DemandHeader>(entity =>
            {
                entity.HasKey(e => e.DphId);

                entity.Property(e => e.DphId).HasColumnName("dphID");

                entity.Property(e => e.AppNum).HasColumnName("appNum");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateCorr)
                    .HasColumnName("dateCorr")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentExec)
                    .HasColumnName("departmentExec")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DpJustification)
                    .HasColumnName("dpJustification")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DphCreator)
                    .IsRequired()
                    .HasColumnName("dphCreator")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DphDate)
                    .HasColumnName("dphDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DphNum)
                    .IsRequired()
                    .HasColumnName("dphNum")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DphStatus).HasColumnName("dphStatus");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Favorites).HasColumnName("favorites");

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtdelId).HasColumnName("otdelID");

                entity.Property(e => e.PhysicalDeliveryOfficeName)
                    .HasColumnName("physicalDeliveryOfficeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.StatusComment)
                    .HasColumnName("statusComment")
                    .IsUnicode(false);

                entity.Property(e => e.Telephonenumber)
                    .HasColumnName("telephonenumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserCorrector)
                    .IsRequired()
                    .HasColumnName("userCorrector")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VersionEditing).HasColumnName("versionEditing");

                entity.Property(e => e.WorkstationCorrector)
                    .IsRequired()
                    .HasColumnName("workstationCorrector")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DphStatusNavigation)
                    .WithMany(p => p.DemandHeader)
                    .HasForeignKey(d => d.DphStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandHeader_DpStatus");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.DemandHeader)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_DemandHeader_ProjectCost");
            });

            modelBuilder.Entity<DemandHeaderArchive>(entity =>
            {
                entity.HasKey(e => e.DahId);

                entity.Property(e => e.DahId).HasColumnName("dahID");

                entity.Property(e => e.DahAction)
                    .IsRequired()
                    .HasColumnName("dahAction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DahFieldsChanged)
                    .HasColumnName("dahFieldsChanged")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DateCorrection)
                    .HasColumnName("dateCorrection")
                    .HasColumnType("datetime");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasColumnName("department")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentExec)
                    .HasColumnName("departmentExec")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DpJustification)
                    .HasColumnName("dpJustification")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DphCreator)
                    .IsRequired()
                    .HasColumnName("dphCreator")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DphDate)
                    .HasColumnName("dphDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.DphId).HasColumnName("dphID");

                entity.Property(e => e.DphNum)
                    .IsRequired()
                    .HasColumnName("dphNum")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DphStatus).HasColumnName("dphStatus");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Manager)
                    .HasColumnName("manager")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhysicalDeliveryOfficeName)
                    .HasColumnName("physicalDeliveryOfficeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId).HasColumnName("projectID");

                entity.Property(e => e.StatusComment)
                    .HasColumnName("statusComment")
                    .IsUnicode(false);

                entity.Property(e => e.Telephonenumber)
                    .HasColumnName("telephonenumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TokenTrans)
                    .HasColumnName("tokenTrans")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserCorrector)
                    .IsRequired()
                    .HasColumnName("userCorrector")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VersionEditing).HasColumnName("versionEditing");

                entity.Property(e => e.WorkstationCorrector)
                    .IsRequired()
                    .HasColumnName("workstationCorrector")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DphStatusNavigation)
                    .WithMany(p => p.DemandHeaderArchive)
                    .HasForeignKey(d => d.DphStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandHeaderArchive_DpStatus");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.DemandHeaderArchive)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_DemandHeaderArchive_ProjectCost");
            });

            modelBuilder.Entity<DemandPurchase>(entity =>
            {
                entity.HasKey(e => e.DpId);

                entity.Property(e => e.DpId).HasColumnName("dpID");

                entity.Property(e => e.DateCorr)
                    .HasColumnName("dateCorr")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateWait)
                    .HasColumnName("dateWait")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartmentExec)
                    .IsRequired()
                    .HasColumnName("departmentExec")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('DE')");

                entity.Property(e => e.DpAmount).HasColumnName("dpAmount");

                entity.Property(e => e.DpComment)
                    .HasColumnName("dpComment")
                    .IsUnicode(false);

                entity.Property(e => e.DpExecutor)
                    .HasColumnName("dpExecutor")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DpIsMobil)
                    .HasColumnName("dpIsMobil")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DpNum).HasColumnName("dpNum");

                entity.Property(e => e.DpStatusId).HasColumnName("dpStatusID");

                entity.Property(e => e.DpSubject)
                    .IsRequired()
                    .HasColumnName("dpSubject")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DpUnit)
                    .IsRequired()
                    .HasColumnName("dpUnit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DphId).HasColumnName("dphID");

                entity.Property(e => e.ExecutorMail)
                    .HasColumnName("executorMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExecutorTelephone)
                    .HasColumnName("executorTelephone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.FirmId)
                    .HasColumnName("firmID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FirmName)
                    .HasColumnName("firmName")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.HousingId).HasColumnName("housingID");

                entity.Property(e => e.ItemCatNum).HasColumnName("itemCatNum");

                entity.Property(e => e.Place)
                    .HasColumnName("place")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.ProdCatNum)
                    .HasColumnName("prodCatNum")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ProdCatNumExist)
                    .HasColumnName("prodCatNumExist")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QualificationId)
                    .HasColumnName("qualificationID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserCorr)
                    .IsRequired()
                    .HasColumnName("userCorr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkstationCorr)
                    .IsRequired()
                    .HasColumnName("workstationCorr")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DpStatus)
                    .WithMany(p => p.DemandPurchase)
                    .HasForeignKey(d => d.DpStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandPurchase_DpStatus");

                entity.HasOne(d => d.Dph)
                    .WithMany(p => p.DemandPurchase)
                    .HasForeignKey(d => d.DphId)
                    .HasConstraintName("FK_DemandPurchase_DemandHeader");
            });

            modelBuilder.Entity<DemandsInUse>(entity =>
            {
                entity.HasKey(e => e.DphId)
                    .HasName("PK_DemandInUse");

                entity.Property(e => e.DphId)
                    .HasColumnName("dphID")
                    .ValueGeneratedNever();

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepartmentExecute>(entity =>
            {
                entity.HasKey(e => e.DepartmentExec);

                entity.Property(e => e.DepartmentExec)
                    .HasColumnName("departmentExec")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Deputy>(entity =>
            {
                entity.Property(e => e.DeputyId).HasColumnName("deputyID");

                entity.Property(e => e.ChiefName)
                    .IsRequired()
                    .HasColumnName("chiefName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeputyName)
                    .IsRequired()
                    .HasColumnName("deputyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlagActing)
                    .IsRequired()
                    .HasColumnName("flagActing")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FlagActingRequest).HasColumnName("flagActingRequest");
            });

            modelBuilder.Entity<DpStatus>(entity =>
            {
                entity.Property(e => e.DpStatusId)
                    .HasColumnName("dpStatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DpStatus1)
                    .IsRequired()
                    .HasColumnName("dpStatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Housing>(entity =>
            {
                entity.HasKey(e => e.HousingId)
                    .HasName("housingID_PK")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.HousingId)
                    .HasColumnName("housingID")
                    .ValueGeneratedNever();

                entity.Property(e => e.HousingAdress)
                    .HasColumnName("housingAdress")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HousingName)
                    .IsRequired()
                    .HasColumnName("housingName")
                    .HasMaxLength(50);

                entity.Property(e => e.ZonеId).HasColumnName("zonеID");
            });

            modelBuilder.Entity<Problems>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .IsRequired()
                    .HasColumnName("FIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PDate)
                    .HasColumnName("pDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ProjectCost>(entity =>
            {
                entity.HasKey(e => e.PId);

                entity.Property(e => e.PId).HasColumnName("pID");

                entity.Property(e => e.PDesignId)
                    .HasColumnName("pDesignID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PName)
                    .IsRequired()
                    .HasColumnName("pName")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
    //public class DemandContext : DbContext
    //{
    //    public DbSet<DemandHeader> DemandHeaders { get; set; }
    //}
}
