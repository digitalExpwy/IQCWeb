namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    
    public class IncomingDMR
    {
       
        public int DMR_ID { get; set; }
       
        public int InspID { get; set; }

        
        public string DMR { get; set; }

        public DateTime? DmrDate { get; set; }

        public int? ApprovedBy { get; set; }

        public DateTime? DispDate { get; set; }

        public int? QtyDefs { get; set; }

        public int? QtyAccepted { get; set; }

        public int? QtyRejected { get; set; }

        public int? Engineering { get; set; }

        public int? MfrEngineering { get; set; }

        public int? ProdControl { get; set; }

        public int? Purchasing { get; set; }

        public int? QAEngineering { get; set; }

        public int? MrbCoordinator { get; set; }

        public bool? Status { get; set; }

        public DateTime? StatusClosedDate { get; set; }

        public DateTime? EmailSent { get; set; }

        public bool? SendDMR { get; set; }

        
        public string Edistro { get; set; }

        public int? DefNum { get; set; }

        public int? BusGroup { get; set; }

        public bool? Void { get; set; }

        public int? Reason_ID { get; set; }

       
        public string QualityNotification { get; set; }

        //public Employees Employees { get; set; }
        public Reasons Reasons { get; set; }
       
        public Inspections Inspections { get; set; }
    }
}
