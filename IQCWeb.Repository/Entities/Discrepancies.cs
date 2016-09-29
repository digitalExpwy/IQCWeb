namespace IQCWeb.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Discrepancies
    {
        [Key]
        public int DisID { get; set; }

        public int? InspID { get; set; }

        public int? Counter { get; set; }

        [StringLength(255)]
        public string Spec { get; set; }

        [StringLength(255)]
        public string Discrepancy { get; set; }

        [StringLength(255)]
        public string DateCodeSN { get; set; }

        public int? QtyInSample { get; set; }

        [StringLength(5)]
        public string DefectCode { get; set; }

        public int? HoneywellDefCode { get; set; }

        public int? Cause { get; set; }
    }
}
