namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Inspections
    {
        public Inspections()
        {
            Molds = new HashSet<Molds>();
            FirstPieceReports = new HashSet<FirstPieceReports>();
        }

        [Key]
        public int InspID { get; set; }


        public DateTime? DateInspected { get; set; }

        [StringLength(30)]
        public string PartNum { get; set; }

        [StringLength(9)]
        public string Revision { get; set; }

        [StringLength(15)]
        public string DateCode { get; set; }

        public int? QtyReceived { get; set; }

        public byte? UMnum { get; set; }

        public int? SampleSize { get; set; }

        public int? VendorID { get; set; }

        public int? MfrId { get; set; }

        public bool? IsSupplier { get; set; }

        public int? CountryID { get; set; }

        public int? PO { get; set; }

        public int? RcvrNum { get; set; }

        public DateTime? RcvrDate { get; set; }

        public int? EmployeeCounter { get; set; }

        public byte? LocationID { get; set; }

        public DateTime? QC_In { get; set; }

        public DateTime? QC_Out { get; set; }

        public bool? FirstPce { get; set; }

        public bool? FirstAppr { get; set; }

        public bool? PrevInsp { get; set; }

        [StringLength(500)]
        public string Comments { get; set; }

        public byte? IsInc { get; set; }

        public bool? Accept { get; set; }

        public DateTime? RecordDate { get; set; }

        [StringLength(1)]
        public string Buyer { get; set; }

        [StringLength(6)]
        public string Priority { get; set; }

        [StringLength(30)]
        public string MfrPartNum { get; set; }

        public bool? IsSAPVendor { get; set; }


        
        public virtual AVM AVM { get; set; }
        public virtual Mfrs Mfrs { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Locations Locations { get; set; }
        public virtual IIM IIM { get; set; }


        public virtual ICollection<Molds> Molds { get; set; }

        public virtual ICollection<FirstPieceReports> FirstPieceReports { get; set; }

    }
}
