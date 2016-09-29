namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Inspections
    {
        
        public int InspID { get; set; }


        public DateTime? DateInspected { get; set; }

        
        public string PartNum { get; set; }

       
        public string Revision { get; set; }

        
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

        
        public string Comments { get; set; }

        public byte? IsInc { get; set; }

        public bool? Accept { get; set; }

        public DateTime? RecordDate { get; set; }

       
        public string Buyer { get; set; }

        
        public string Priority { get; set; }

        
        public string MfrPartNum { get; set; }

        public bool? IsSAPVendor { get; set; }

        public Countries Countries { get; set; }
        public AVM AVM { get; set; }
        public IIM IIM { get; set; }
        public Employees Employees { get; set; }
        public Locations Locations { get; set; }

        public virtual ICollection<Molds> Molds { get; set; }

        public virtual ICollection<FirstPieceReports> FirstPieceReports { get; set; }

    }
}
