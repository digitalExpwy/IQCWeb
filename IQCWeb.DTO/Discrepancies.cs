namespace IQCWeb.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Discrepancies
    {
        
        public int DisID { get; set; }

        public int? InspID { get; set; }

        public int? Counter { get; set; }

        public string Spec { get; set; }

        
        public string Discrepancy { get; set; }

        
        public string DateCodeSN { get; set; }

        public int? QtyInSample { get; set; }

        
        public string DefectCode { get; set; }

        public int? HoneywellDefCode { get; set; }

        public int? Cause { get; set; }
    }
}
