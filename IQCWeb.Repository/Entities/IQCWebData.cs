namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class IQCWebData : DbContext
    {
        public IQCWebData()
            : base("name=IQCWebData")
        {
        }

        public virtual DbSet<DimensionalDefects> DimensionalDefects { get; set; }
        public virtual DbSet<DMR_Attachments> DMR_Attachments { get; set; }
        public virtual DbSet<FirstPieceReports> FirstPieceReports { get; set; }
        public virtual DbSet<FPR_RejReasons> FPR_RejReasons { get; set; }
        public virtual DbSet<IncomingDMR> IncomingDMR { get; set; }
        public virtual DbSet<Inspections> Inspections { get; set; }
        public virtual DbSet<Molds> Molds { get; set; }
        public virtual DbSet<NonDimensionalDefects> NonDimensionalDefects { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<AVM> AVM { get; set; }
        public virtual DbSet<Causes> Causes { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<DefectAdjective> DefectAdjective { get; set; }
        public virtual DbSet<DefectNoun> DefectNoun { get; set; }
        public virtual DbSet<Definitions> Definitions { get; set; }
        public virtual DbSet<DesignSites> DesignSites { get; set; }
        public virtual DbSet<Discrepancies> Discrepancies { get; set; }
        public virtual DbSet<DispositionCodes> DispositionCodes { get; set; }
        public virtual DbSet<DMR_ActionTaken> DMR_ActionTaken { get; set; }
        public virtual DbSet<DMR_Dispositions> DMR_Dispositions { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<HoneywellDefectCodeTranslation> HoneywellDefectCodeTranslation { get; set; }
        public virtual DbSet<IIM> IIM { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<MainLocations> MainLocations { get; set; }
        public virtual DbSet<Mfrs> Mfrs { get; set; }
        public virtual DbSet<PurchasedParts> PurchasedParts { get; set; }
        public virtual DbSet<Reasons> Reasons { get; set; }
        public virtual DbSet<RFI> RFI { get; set; }
        public virtual DbSet<UM> UM { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<FirstPieceReports>()
                .Property(e => e.FPR)
                .IsUnicode(false);

            modelBuilder.Entity<FirstPieceReports>()
                .Property(e => e.RejReason)
                .IsUnicode(false);

            modelBuilder.Entity<IncomingDMR>()
                .Property(e => e.DMR)
                .IsUnicode(false);

            modelBuilder.Entity<IncomingDMR>()
                .Property(e => e.Edistro)
                .IsUnicode(false);

            modelBuilder.Entity<IncomingDMR>()
                .Property(e => e.QualityNotification)
                .IsUnicode(false);

            modelBuilder.Entity<Inspections>()
                .Property(e => e.PartNum)
                .IsUnicode(false);

            modelBuilder.Entity<Inspections>()
                .Property(e => e.Buyer)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Inspections>()
                .Property(e => e.MfrPartNum)
                .IsUnicode(false);

            modelBuilder.Entity<Molds>()
                .Property(e => e.PartNum)
                .IsUnicode(false);

            modelBuilder.Entity<Molds>()
                .Property(e => e.MoldNum)
                .IsUnicode(false);

            modelBuilder.Entity<Molds>()
                .Property(e => e.ResinUsed)
                .IsUnicode(false);

            modelBuilder.Entity<Molds>()
                .Property(e => e.MoldRev)
                .IsUnicode(false);

            modelBuilder.Entity<UserRoles>()
                .Property(e => e.EID)
                .IsUnicode(false);

            modelBuilder.Entity<AVM>()
                .Property(e => e.VendorName)
                .IsUnicode(false);
          
            modelBuilder.Entity<DefectAdjective>()
                .Property(e => e.Adjective)
                .IsUnicode(false);

            modelBuilder.Entity<DefectNoun>()
                .Property(e => e.Noun)
                .IsUnicode(false);

            modelBuilder.Entity<Definitions>()
                .Property(e => e.DefinitionName)
                .IsUnicode(false);

            modelBuilder.Entity<Definitions>()
                .Property(e => e.DefinitionText)
                .IsUnicode(false);

            modelBuilder.Entity<DesignSites>()
                .Property(e => e.DesignSite)
                .IsUnicode(false);

            modelBuilder.Entity<DesignSites>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Discrepancies>()
                .Property(e => e.Spec)
                .IsUnicode(false);

            modelBuilder.Entity<Discrepancies>()
                .Property(e => e.Discrepancy)
                .IsUnicode(false);

            modelBuilder.Entity<Discrepancies>()
                .Property(e => e.DateCodeSN)
                .IsUnicode(false);

            modelBuilder.Entity<Discrepancies>()
                .Property(e => e.DefectCode)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.EmpFunction)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.BuyerCode)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.EID)
                .IsUnicode(false);

            modelBuilder.Entity<HoneywellDefectCodeTranslation>()
                .Property(e => e.DefectCode)
                .IsUnicode(false);

            modelBuilder.Entity<IIM>()
                .Property(e => e.PartNum)
                .IsUnicode(false);

            modelBuilder.Entity<IIM>()
                .Property(e => e.PartDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Locations>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Locations>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<PurchasedParts>()
                .Property(e => e.PartNum)
                .IsUnicode(false);

            modelBuilder.Entity<Reasons>()
                .Property(e => e.ReasonCode)
                .IsUnicode(false);

            modelBuilder.Entity<RFI>()
                .Property(e => e.RFI_Name)
                .IsUnicode(false);
        }
    }
}
